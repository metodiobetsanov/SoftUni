namespace SIS.HTTP.Contracts
{
    using SIS.HTTP.Enums;

    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; set; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        byte[] Content { get; set; }

        void AddHeader(IHttpHeader httpHeader);

        void AddCookie(IHttpCookie httpCookie);

        byte[] GetBytes();
    }
}