namespace SIS.FRAMEWORK.Attributes.Property
{
    using System;

    public abstract class ValidationAttributes : Attribute
    {
        public abstract bool IsValid(object value);
    }
}