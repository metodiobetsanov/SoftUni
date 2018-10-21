namespace SIS.HTTP.Cookies
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Contracts;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly IDictionary<string, IHttpCookie> data;

        public HttpCookieCollection()
        {
            this.data = new Dictionary<string, IHttpCookie>();
        }

        public void Add(IHttpCookie cookie)
        {
            CoreValidator.ThrowIfNull(cookie, nameof(cookie));
            if (!this.ContainsCookies(cookie.Key))
            {
                this.data.Add(cookie.Key, cookie);
            }
        }

        public bool ContainsCookies(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            return this.data.ContainsKey(key);
        }

        public IHttpCookie GetCookie(string key)
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

        public void Clear()
        {
            this.data.Clear();
        }

        public override string ToString()
        {
            return string.Join("; ", this.data.Values);
        }

        public IEnumerator<IHttpCookie> GetEnumerator()
        {
            foreach (var cookie in this.data)
            {
                yield return cookie.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}