namespace SIS.HTTP.Headers
{
    using Contracts;

    using SIS.HTTP.Common;

    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        public readonly Dictionary<string, IHttpHeader> data;

        public HttpHeaderCollection()
        {
            this.data = new Dictionary<string, IHttpHeader>();
        }

        public void Add(IHttpHeader httpHeader)
        {
            CoreValidator.ThrowIfNullOrEmpty(httpHeader.Key, nameof(httpHeader.Key));
            CoreValidator.ThrowIfNullOrEmpty(httpHeader.Value, nameof(httpHeader.Value));

            if (this.data.ContainsKey(httpHeader.Key))
            {
                throw new ArgumentException($"Key: {httpHeader.Key}, already pressent");
            }

            this.data.Add(httpHeader.Key, httpHeader);
        }

        public bool ContainsHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            return this.data.ContainsKey(key);
        }

        public IHttpHeader GetHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            if (!ContainsHeader(key))
            {
                return null;
            }
            return this.data[key];
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.data.Values);
        }

        IEnumerator<IHttpHeader> IEnumerable<IHttpHeader>.GetEnumerator()
            => this.data.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.data.Values.GetEnumerator();
    }
}