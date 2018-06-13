namespace Framework.Attributes.Methods
{
    using System;

    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToUpper() == "GET")
            {
                return true;
            }

            return false;
        }
    }
}