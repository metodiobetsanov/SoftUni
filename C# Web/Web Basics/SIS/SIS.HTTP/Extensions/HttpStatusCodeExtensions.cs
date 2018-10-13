namespace SIS.HTTP.Extensions
{
    using SIS.HTTP.Enums;

    public static class HttpStatusCodeExtensions
    {
        public static string GetResponseLine(this HttpStatusCode statusCode)
        {
            return $"{(int)statusCode} {statusCode}";
        }
    }
}