namespace Framework.Attributes.Methods
{
    using System;

    public class HttpPostAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToUpper() == "POST")
            {
                return true;
            }
            else return false;
        }
    }
}