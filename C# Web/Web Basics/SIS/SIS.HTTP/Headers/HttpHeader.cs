﻿namespace SIS.HTTP.Headers
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Contracts;

    public class HttpHeader : IHttpHeader
    {
        public const string ContentDisposition = "Content Disposition";
        public const string ContentLenght = "Content-Lenght";
        public const string ContentType = "Content-Type";
        public const string Host = "Host";
        public const string Location = "Location";
        public const string Cookie = "Cookie";
        public const string SetCookie = "Set-Cookie";

        public HttpHeader(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.Key = key;
            this.Value = value;
        }

        public string Key { get; }

        public string Value { get; }

        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}