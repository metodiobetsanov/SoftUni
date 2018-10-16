using System.Collections.Generic;

namespace SIS.HTTP.Contracts
{
    public interface IHttpHeaderCollection : IEnumerable<IHttpHeader>
    {
        void Add(IHttpHeader httpHeader);

        bool ContainsHeader(string key);

        IHttpHeader GetHeader(string key);
    }
}