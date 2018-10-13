namespace SIS.HTTP.Contracts
{
    using Headers;

    public interface IHttpHeaderCollection
    {
        void Add(HttpHeader httpHeader);

        bool ContainsHeader(string key);

        HttpHeader GetHeader(string key);
    }
}