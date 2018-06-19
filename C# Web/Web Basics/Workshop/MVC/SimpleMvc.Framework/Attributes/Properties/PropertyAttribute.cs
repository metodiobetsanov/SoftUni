namespace SimpleMvc.Framework.Attributes.Properties
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class PropertyAttribute : Attribute
    {
        public abstract bool IsValid(object value);
    }
}