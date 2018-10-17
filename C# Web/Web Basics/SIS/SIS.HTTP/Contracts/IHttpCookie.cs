using System;

namespace SIS.HTTP.Contracts
{
    public interface IHttpCookie
    {
        string Key { get; }

        string Value { get; }

        DateTime Expires { get; }

        bool IsNew { get; }

        void Delete();
    }
}