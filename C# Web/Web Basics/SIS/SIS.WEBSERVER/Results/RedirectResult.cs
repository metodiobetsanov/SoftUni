namespace SIS.WEBSERVER.Results
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Responses;

    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location)
            : base(HttpStatusCode.SeeOther)
        {
            this.Headers.Add(new HttpHeader(HttpHeader.Location, location));
        }
    }
}