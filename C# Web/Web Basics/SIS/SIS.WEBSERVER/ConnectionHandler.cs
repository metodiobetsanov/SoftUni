namespace SIS.WEBSERVER
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Contracts;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Sessions;
    using SIS.WEBSERVER.Routing;

    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly ServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, ServerRoutingTable serverRoutingTable)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(serverRoutingTable, nameof(serverRoutingTable));

            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        public async Task ProcessRequestAsync()
        {
            var httpRequest = await this.ReadRequest();

            if (httpRequest != null)
            {
                string sessionId = this.SetRequestSession(httpRequest);

                var httpResponse = this.HttpRequestHandler(httpRequest);

                this.SetResponseSession(httpResponse, sessionId);

                await this.PrepareResponse(httpResponse);

                Console.WriteLine($"-----REQUEST-----");

                Console.WriteLine(httpRequest);

                Console.WriteLine($"-----RESPONSE-----");

                Console.WriteLine(httpResponse);

                Console.WriteLine();
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private void SetResponseSession(IHttpResponse httpResponse, string sessionId)
        {
            if (sessionId !=null)
            {
                httpResponse.AddCookie(
                    new HttpCookie(
                        HttpSessionStorage.SessionCookieKey,
                        $"{sessionId};HttpOnly=true"
                    ));
            }
        }

        private string SetRequestSession(IHttpRequest httpRequest)
        {
            string sessionId = string.Empty;

            if (httpRequest.Cookies.ContainsCookies(HttpSessionStorage.SessionCookieKey))
            {
                var cookie = httpRequest.Cookies.GetCookie(HttpSessionStorage.SessionCookieKey);
                sessionId = cookie.Value;
                httpRequest.Session = HttpSessionStorage.Get(sessionId);
            }
            else
            {
                sessionId = Guid.NewGuid().ToString();
                httpRequest.Session = HttpSessionStorage.Get(sessionId);
            }

            return sessionId;
        }

        private async Task PrepareResponse(IHttpResponse httpResponse)
        {
            byte[] byteSegment = httpResponse.GetBytes();

            await this.client.SendAsync(byteSegment, SocketFlags.None);
        }

        private IHttpResponse HttpRequestHandler(IHttpRequest httpRequest)
        {
            if (!this.serverRoutingTable.Routes.ContainsKey(httpRequest.RequestMethod)
                || !this.serverRoutingTable.Routes[httpRequest.RequestMethod].ContainsKey(httpRequest.Path))
            {
                return new HttpResponse(HttpStatusCode.NotFound);
            }

            return this.serverRoutingTable.Routes[httpRequest.RequestMethod][httpRequest.Path].Invoke(httpRequest);
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();

            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)

            {
                int numberOfBytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

                if (numberOfBytesRead == 0)

                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);

                result.Append(bytesAsString);

                if (numberOfBytesRead < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }
    }
}