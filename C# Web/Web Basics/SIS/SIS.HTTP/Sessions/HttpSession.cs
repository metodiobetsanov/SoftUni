namespace SIS.HTTP.Sessions
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Contracts;
    using System.Collections.Generic;

    public class HttpSession : IHttpSession
    {
        private readonly IDictionary<string, object> data;

        public HttpSession(string id)
        {
            CoreValidator.ThrowIfNullOrEmpty(id, nameof(id));

            this.Id = id;
            this.data = new Dictionary<string, object>();
        }

        public string Id { get; private set; }

        public void Add(string key, object value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNull(value, nameof(value));

            this.data[key] = value;
        }

        public void Clear() => this.data.Clear();

        public object Get(string key)
        {
            CoreValidator.ThrowIfNull(key, nameof(key));

            if (!this.data.ContainsKey(key))
            {
                return null;
            }

            return this.data[key];
        }

        public T Get<T>(string key)
            => (T)this.Get(key);
    }
}