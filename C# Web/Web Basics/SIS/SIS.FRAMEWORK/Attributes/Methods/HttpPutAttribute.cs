﻿namespace SIS.FRAMEWORK.Attributes.Methods
{
    public class HttpPutAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            return requestMethod.ToUpper() == "PUT";
        }
    }
}