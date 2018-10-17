namespace SIS.FRAMEWORK.ActionResults
{
    using SIS.FRAMEWORK.ActionResults.Contacts;

    public class RedirectResult : IRedirectable
    {
        public RedirectResult(string url)
        {
            this.RedirectUrl = url;
        }

        public string RedirectUrl { get; }

        public string Invoke() => this.RedirectUrl;
    }
}