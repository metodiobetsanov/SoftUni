namespace SIS.HTTP.Headers
{
    using Contracts;

    using System;
    using System.Collections.Generic;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        public readonly Dictionary<string, HttpHeader> data;

        public HttpHeaderCollection()
        {
            this.data = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader httpHeader)
        {
            this.data[httpHeader.Key] = httpHeader;
        }

        public bool ContainsHeader(string key)
        {
            return this.data.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (!ContainsHeader(key))
            {
                return null;
            }
            return this.data[key];
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.data.Values.ToString());
        }
    }
}