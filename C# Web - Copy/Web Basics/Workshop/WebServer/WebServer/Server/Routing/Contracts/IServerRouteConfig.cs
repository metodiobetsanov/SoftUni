namespace WebServer.Server.Routing.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Enums;

    public interface IServerRouteConfig
    {
        Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes { get; }
    }
}