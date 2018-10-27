namespace SIS.FRAMEWORK.Security
{
    using SIS.FRAMEWORK.Security.Generic;
    using System;

    public class IdentityUser : IdentityUserT<string>
    {
        public IdentityUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}