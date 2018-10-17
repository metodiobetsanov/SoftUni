namespace SIS.FRAMEWORK.ActionResults.Contacts
{
    public interface IRedirectable : IActionResult
    {
        string RedirectUrl { get; }
    }
}