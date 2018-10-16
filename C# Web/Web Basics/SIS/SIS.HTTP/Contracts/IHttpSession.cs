

namespace SIS.HTTP.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IHttpSession
    {
        string Id { get; }

        object Get(string key);

        T Get<T>(string key);

        void Add(string key, object value);

        void Clear();

    }
}
