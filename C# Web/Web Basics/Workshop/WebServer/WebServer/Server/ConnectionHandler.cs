namespace WebServer.Server
{
    using Handlers;
    using HTTP;
    using HTTP.Contracts;
    using Routing.Contracts;
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRouteConfig serverRouteConfig;

        public ConnectionHandler(Socket client, IServerRouteConfig serverRouteConfig)
        {
            this.client = client;
            this.serverRouteConfig = serverRouteConfig;
        }

        public async Task ProcessRequestAsync()
        {
            string httpRequest = await this.ReadRequest();

            if (httpRequest != null)
            {
                IHttpContext httpContext = new HttpContext(httpRequest);

                IHttpResponse httpResponse = new HttpHandler(this.serverRouteConfig).Handle(httpContext);

                ArraySegment<byte> toBytes = new ArraySegment<byte>(Encoding.UTF8.GetBytes(httpResponse.ToString()));

                await this.client.SendAsync(toBytes, SocketFlags.None);

                Console.WriteLine($"-----REQUEST-----");
                Console.WriteLine(httpRequest);
                Console.WriteLine($"-----RESPONSE-----");
                Console.WriteLine(httpResponse);
                Console.WriteLine();
            }
            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<string> ReadRequest()
        {
            string request = string.Empty;

            ArraySegment<byte> data = new ArraySegment<byte>(new byte[1024]);

            int numBytesRead;

            while ((numBytesRead = await this.client.ReceiveAsync(data, SocketFlags.None)) > 0)
            {
                request += Encoding.UTF8.GetString(data.Array, 0, numBytesRead);
                if (numBytesRead < 1023)
                {
                    break;
                }
            }

            if (request.Length == 0)
            {
                return null;
            }

            return request.ToString();
        }
    }
}