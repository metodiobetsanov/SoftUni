

namespace SIS.FRAMEWORK.Security.Generic
{
    using SIS.FRAMEWORK.Security.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class IdentityUserT<TKey> : IIdentity
        where TKey : IEquatable<TKey>
    {
        public virtual TKey Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual bool IsValid { get; set; }
        public virtual IEnumerable<string> Roles { get; set; }
    }
}
