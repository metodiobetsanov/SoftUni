namespace WebServer.Server.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using HTTP.Contracts;

    public class GetHandler : RequestHandler
    {
        public GetHandler(Func<IHttpRequest, IHttpResponse> function)
            : base(function)
        {
        }
    }
}