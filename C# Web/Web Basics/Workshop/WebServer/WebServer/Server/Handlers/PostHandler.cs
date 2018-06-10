namespace WebServer.Server.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using HTTP.Contracts;

    public class PostHandler : RequestHandler
    {
        public PostHandler(Func<IHttpRequest, IHttpResponse> function)
            : base(function)
        {
        }
    }
}