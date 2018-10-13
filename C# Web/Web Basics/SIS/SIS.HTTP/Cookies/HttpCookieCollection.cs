

namespace SIS.HTTP.Cookies
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly IDictionary<string, HttpCookie> data;

        public HttpCookieCollection()
        {
            this.data = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            CoreValidator.ThrowIfNull(cookie, nameof(cookie));

            this.data[cookie.Key] = cookie;
        }

        public bool ContainsCookies(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            return this.data.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            if (!this.ContainsCookies(key))
            {
                return null;
            }

            return this.data[key];
        }

        public bool HasCookies()
        {
            return this.data.Any();
        }

        public override string ToString()
        {
            return string.Join( ";", this.data.Values);
        }
    }
}
