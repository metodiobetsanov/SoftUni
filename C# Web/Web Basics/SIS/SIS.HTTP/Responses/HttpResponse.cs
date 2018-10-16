namespace SIS.HTTP.Responses
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Contracts;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Extensions;
    using SIS.HTTP.Headers;

    using System.Linq;
    using System.Text;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {
        }

        public HttpResponse(HttpStatusCode responseCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
            this.Content = new byte[0];
            this.StatusCode = responseCode;
        }

        public HttpStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public IHttpCookieCollection Cookies { get; private set; }

        public byte[] Content { get; set; }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();
        }

        public void AddHeader(IHttpHeader httpHeader)
        {
            this.Headers.Add(httpHeader);
        }

        public void AddCookie(IHttpCookie httpCookie)
        {
            this.Cookies.Add(httpCookie);
        }

        public override string ToString()
        {
            var response = new StringBuilder();

            response.AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}");
            response.AppendLine(this.Headers.ToString());

            if (this.Cookies.HasCookies())
            {
                response.AppendLine($"{GlobalConstants.SetCookies}: {this.Cookies}");
            }

            response.AppendLine();

            return response.ToString();
        }
    }
}