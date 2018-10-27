namespace SIS.FRAMEWORK.Security.Contracts
{
    using System.Collections.Generic;

    public interface IIdentity
    {
        string Username { get; set; }

        string Password { get; set; }

        string Email { get; set; }

        bool IsValid { get; set; }

        ICollection<string> Roles { get; set; }
    }
}