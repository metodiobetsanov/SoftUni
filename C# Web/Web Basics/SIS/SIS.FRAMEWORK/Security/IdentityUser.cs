

namespace SIS.FRAMEWORK.Security
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SIS.FRAMEWORK.Security.Generic;
    public class IdentityUser : IdentityUserT<string>
    {
        public IdentityUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
