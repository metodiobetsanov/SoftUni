namespace SIS.HTTP.Contracts
{
    using SIS.HTTP.Cookies;

    using System.Collections.Generic;

    public interface IHttpCookieCollection : IEnumerable<IHttpCookie>
    {
        void Add(IHttpCookie cookie);

        bool ContainsCookies(string key);

        bool HasCookies();

        HttpCookie GetCookie(string key);
    }
}