
namespace SimpleMvc.Framework.Security
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Authentication
    {
        internal Authentication()
        {
            this.IsAuthenticated = false;
        }

        internal Authentication(string name)
        {
            this.Name = name;

            this.IsAuthenticated = true;
        }

        public bool IsAuthenticated { get; private set; }

        public string Name { get; internal set; }
    }
}
