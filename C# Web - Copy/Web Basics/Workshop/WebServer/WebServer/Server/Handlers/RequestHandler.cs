namespace WebServer.Server.Handlers
{
    using System;
    using Handlers.Contracts;
    using HTTP.Contracts;

    public abstract class RequestHandler : IRequestHandler
    {
        protected RequestHandler(Func<IHttpRequest, IHttpResponse> function)
        {
            this.Func = function;
        }

        private readonly Func<IHttpRequest, IHttpResponse> Func;

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            IHttpResponse httpResponse = this.Func.Invoke(httpContext.Request);

            httpResponse.AddHeader("Content-Type", "text/html");

            return httpResponse;
        }
    }
}