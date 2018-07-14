namespace WebServer.Server.HTTP
{
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, IHttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, IHttpHeader>();
        }

        public void Add(IHttpHeader header)
        {
            this.headers[header.Key] = header;
        }

        public bool ContainsKey(string key)
        {
            return this.headers.ContainsKey(key);
        }

        public IHttpHeader GetHeader(string key)
        {
            if (this.ContainsKey(key))
            {
                return this.headers[key];
            }

            return null;
        }

        public override string ToString() => string.Join(Environment.NewLine, this.headers);
    }
}