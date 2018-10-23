

namespace SIS.FRAMEWORK.Attributes.Action
{
    using SIS.FRAMEWORK.Security.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class AuthorizeAttribute : Attribute
    {
        private readonly string[] roles;

        public AuthorizeAttribute()
        {

        }

        public AuthorizeAttribute(params string[] roles)
        {
            this.roles = roles;
        }

        private bool IsIdentityPresent(IIdentity identity)
        {
            return identity != null;
        }

        private bool IsIdentityInRole(IIdentity identity)
        {
            if (!this.IsIdentityPresent(identity))
            {
                return false;
            }

            var identityRoles = identity.Roles;

            foreach (var role in identityRoles)
            {
                if (this.roles.Contains(role))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsAuthorized(IIdentity user)
        {
            if (this.roles == null || !this.roles.Any())
            {
                return this.IsIdentityPresent(user);
            }

            return this.IsIdentityInRole(user);
        }
    }
}
