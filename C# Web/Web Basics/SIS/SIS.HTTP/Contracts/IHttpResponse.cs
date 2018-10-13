namespace SIS.HTTP.Contracts
{
    using SIS.HTTP.Enums;

    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; set; }

        IHttpHeaderCollection Headers { get; }

        byte[] Content { get; set; }

        void AddHeader(IHttpHeader httpHeader);

        byte[] GetBytes();
    }
}