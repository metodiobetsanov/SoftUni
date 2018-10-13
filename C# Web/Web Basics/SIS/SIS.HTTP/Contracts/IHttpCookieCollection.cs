

namespace SIS.HTTP.Contracts
{
    using SIS.HTTP.Cookies;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IHttpCookieCollection
    {
        void Add(HttpCookie cookie);

        bool ContainsCookies(string key);

        bool HasCookies();

        HttpCookie GetCookie(string key);
    }
}
