namespace SIS.HTTP.Contracts
{
    public interface IHttpSession
    {
        string Id { get; }

        object Get(string key);

        T Get<T>(string key);

        bool ContainsParameter(string key);

        void AddParameter(string key, object value);

        void Clear();
    }
}