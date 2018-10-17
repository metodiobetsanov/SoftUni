namespace SIS.WEBSERVER
{
    using SIS.WEBSERVER.Api;

    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class WebServer
    {
        private const string localHostIpAddress = "127.0.0.1";

        private readonly int port;

        private readonly TcpListener listener;

        private IHandleable httpHandler;

        private bool isRunning;

        public WebServer(int port, IHandleable httpHandler)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(localHostIpAddress), port);
            this.httpHandler = httpHandler;
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"WebServer running on {localHostIpAddress}:{this.port}");

            Task.Run(this.ListenLoop).Wait();
        }

        private async Task ListenLoop()
        {
            while (this.isRunning)
            {
                var client = await this.listener.AcceptSocketAsync();
                var connectionHandler = new ConnectionHandler(client, this.httpHandler);
                await connectionHandler.ProcessRequestAsync();
            }
        }
    }
}