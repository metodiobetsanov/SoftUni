namespace SIS.HTTP.Sessions
{
    using SIS.HTTP.Contracts;
    using System;
    using System.Collections.Concurrent;

    public class HttpSessionStorage : IHttpSessionStorage
    {
        public const string SessionCookieKey = "SIS_ID";

        private static readonly ConcurrentDictionary<string, IHttpSession> sessions =
            new ConcurrentDictionary<string, IHttpSession>();

        public static IHttpSession Get(string id)
            => sessions.GetOrAdd(id, _ => new HttpSession(id));
    }
}