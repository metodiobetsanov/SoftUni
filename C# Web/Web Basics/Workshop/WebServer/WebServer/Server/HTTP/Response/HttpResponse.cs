namespace WebServer.Server.HTTP.Response
{
    using System.Text;
    using Enums;
    using Contracts;

    public abstract class HttpResponse : IHttpResponse
    {
        protected HttpResponse()
        {
            this.HeaderCollection = new HttpHeaderCollection();
        }

        protected IHttpHeaderCollection HeaderCollection { get; set; }

        protected HttpStatusCode StatusCode { get; set; }

        protected string StatusMessage => this.StatusCode.ToString();

        public void AddHeader(string key, string value)
        {
            this.HeaderCollection.Add(
                new HttpHeader(key, value)
                );
        }

        public override string ToString()
        {
            StringBuilder response = new StringBuilder();

            response.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusMessage}");

            response.AppendLine(this.HeaderCollection.ToString());
            response.AppendLine();

            return response.ToString();
        }
    }
}