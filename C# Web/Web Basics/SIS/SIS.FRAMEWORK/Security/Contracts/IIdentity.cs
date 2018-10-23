

namespace SIS.FRAMEWORK.Security.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IIdentity
    {
        string Username { get; set; }

        string Password { get; set; }

        string Email { get; set; }

        bool IsValid { get; set; }

        IEnumerable<string> Roles { get; set; }
    }
}
