namespace WebServer.Server.Routing.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Handlers;
    using Handlers.Contracts;

    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        IRequestHandler RequestHandler { get; }
    }
}