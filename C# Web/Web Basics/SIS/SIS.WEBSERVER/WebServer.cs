namespace SIS.WEBSERVER
{
    using SIS.WEBSERVER.Api;

    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class WebServer
    {
        private const string localHostIpAddress = "127.1.1.1";

        private readonly int port;

        private readonly TcpListener listener;

        private IHandleable httpHandler;

        private IHandleable resourceHandler;

        private bool isRunning;

        public WebServer(int port, IHandleable httpHandler, IHandleable resourceHandler)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(localHostIpAddress), port);
            this.httpHandler = httpHandler;
            this.resourceHandler = resourceHandler;
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started at http://{localHostIpAddress}:{this.port}");
            while (isRunning)
            {
                Console.WriteLine("Waiting for client...");

                var client = listener.AcceptSocketAsync().GetAwaiter().GetResult();

                Task.Run(() => Listen(client));
            }
        }

        public async void Listen(Socket client)
        {
            var connectionHandler = new ConnectionHandler(client, this.httpHandler, this.resourceHandler);
            await connectionHandler.ProcessRequestAsync();
        }
    }
}