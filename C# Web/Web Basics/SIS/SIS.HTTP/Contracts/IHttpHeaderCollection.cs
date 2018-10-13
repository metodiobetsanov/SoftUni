namespace SIS.HTTP.Contracts
{
    public interface IHttpHeaderCollection
    {
        void Add(IHttpHeader httpHeader);

        bool ContainsHeader(string key);

        IHttpHeader GetHeader(string key);
    }
}