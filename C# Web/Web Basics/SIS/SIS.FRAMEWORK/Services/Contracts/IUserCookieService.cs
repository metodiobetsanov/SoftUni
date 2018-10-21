namespace SIS.FRAMEWORK.Services.Contracts
{
    public interface IUserCookieService
    {
        string GetUserCookie(string userName);

        string GetUserData(string cookieContent);

        string EncryptString(string text, string keyString);

        string DecryptString(string cipherText, string keyString);
    }
}