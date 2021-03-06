﻿namespace SIS.HTTP.Contracts
{
    using System.Collections.Generic;

    public interface IHttpCookieCollection : IEnumerable<IHttpCookie>
    {
        void Add(IHttpCookie cookie);

        bool ContainsCookies(string key);

        bool HasCookies();

        void Clear();

        IHttpCookie GetCookie(string key);
    }
}