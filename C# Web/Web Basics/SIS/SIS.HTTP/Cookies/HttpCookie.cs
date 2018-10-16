namespace SIS.HTTP.Cookies
{
    using SIS.HTTP.Contracts;

    using System;

    public class HttpCookie : IHttpCookie
    {
        public HttpCookie(string key, string value, int expires = 3)
        {
            this.Key = key;
            this.Value = value;
            this.IsNew = true;
            this.Expires = DateTime.UtcNow.AddDays(expires);
        }

        public HttpCookie(string key, string value, bool isNew, int expires = 3)
            : this(key, value, expires)
        {
            this.IsNew = isNew;
        }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public DateTime Expires { get; private set; }

        public bool IsNew { get; private set; } = true;

        public override string ToString()
            => $"{this.Key}={this.Value}";
    }
}