namespace WebServer.Server.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using Handlers.Contracts;
    using HTTP.Contracts;
    using Routing.Contracts;

    public class HttpHandler : IRequestHandler
    {
        public HttpHandler(IServerRouteConfig serverRouteConf)
        {
            this.serverRouteConfig = serverRouteConf;
        }

        private readonly IServerRouteConfig serverRouteConfig;

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            foreach (KeyValuePair<string, IRoutingContext> kvp in this.serverRouteConfig.Routes[httpContext.Request.RequestMethod])
            {
                string pattern = kvp.Key;
                Regex regex = new Regex(pattern);
                Match match = regex.Match(httpContext.Request.Path);

                if (!match.Success)
                {
                    continue;
                }

                foreach (string parameter in kvp.Value.Parameters)
                {
                    httpContext.Request.AddUrlParameters(parameter, match.Groups[parameter].Value);
                }

                return kvp.Value.RequestHandler.Handle(httpContext);
            }

            return null;
        }
    }
}