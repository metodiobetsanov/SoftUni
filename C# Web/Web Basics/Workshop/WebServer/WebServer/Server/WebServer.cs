namespace WebServer.Server
{
    using Contracts;
    using Routing;
    using Routing.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class WebServer : IRunnable
    {
        private readonly int port;

        private readonly string ipAddress;

        private readonly IServerRouteConfig serverRouteConfig;

        private readonly TcpListener tcpListener;

        private bool isRunning;

        public WebServer(string ipAddress, int port, IAppRouteConfig appRouteConfig)
        {
            this.port = port;
            this.ipAddress = ipAddress;
            this.tcpListener = new TcpListener(IPAddress.Parse(this.ipAddress), this.port);

            this.serverRouteConfig = new ServerRouteConfig(appRouteConfig);
        }

        public void Run()
        {
            this.tcpListener.Start();

            this.isRunning = true;

            Console.WriteLine($"Server started. Listening to TCP clients at {this.ipAddress}:{this.port}");

            Task task = Task.Run(this.ListenLoop);

            task.Wait();
        }

        private async Task ListenLoop()
        {
            while (this.isRunning)
            {
                Socket client = await this.tcpListener.AcceptSocketAsync();
                ConnectionHandler connectionHandler = new ConnectionHandler(client, this.serverRouteConfig);
                Task connection = connectionHandler.ProcessRequestAsync();
                connection.Wait();
            }
        }
    }
}