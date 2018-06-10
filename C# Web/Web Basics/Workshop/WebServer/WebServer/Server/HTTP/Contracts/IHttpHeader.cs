namespace WebServer.Server.HTTP.Contracts
{
    public interface IHttpHeader
    {
        string Key { get; }
        string Value { get; }
    }
}