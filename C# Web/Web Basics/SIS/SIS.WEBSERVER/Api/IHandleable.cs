namespace SIS.WEBSERVER.Api
{
    using SIS.HTTP.Contracts;

    public interface IHandleable
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}