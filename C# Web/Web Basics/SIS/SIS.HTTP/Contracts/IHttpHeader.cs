namespace SIS.HTTP.Contracts
{
    public interface IHttpHeader
    {
        string Key { get; }

        string Value { get; }
    }
}