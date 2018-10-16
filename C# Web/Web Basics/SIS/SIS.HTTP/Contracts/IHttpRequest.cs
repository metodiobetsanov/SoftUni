namespace SIS.HTTP.Contracts
{
    using SIS.HTTP.Enums;

    using System.Collections.Generic;

    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        Dictionary<string, object> FormData { get; }

        Dictionary<string, object> QueryData { get; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        IHttpSession Session { get; set; }

        HttpRequestMethod RequestMethod { get; }
    }
}