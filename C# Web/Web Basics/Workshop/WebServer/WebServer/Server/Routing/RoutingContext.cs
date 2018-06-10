namespace WebServer.Server.Routing
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Handlers;
    using Handlers.Contracts;
    using Routing.Contracts;

    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(IRequestHandler requestHandler, IEnumerable<string> args)
        {
            this.Parameters = args;
            this.RequestHandler = requestHandler;
        }

        public IEnumerable<string> Parameters { get; }

        public IRequestHandler RequestHandler { get; }
    }
}