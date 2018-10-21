namespace IRunes.Controllers
{
    using IRunes.Data;
    using IRunes.Common;
    using SIS.FRAMEWORK.Controllers;
    using SIS.FRAMEWORK.Services.Contracts;
    using SIS.HTTP.Contracts;
    using SIS.HTTP.Cookies;

    public abstract class BaseController : Controller
    {
        protected IUserCookieService UserCookieService { get; }

        protected string Error { get; set; }

        protected BaseController(IUserCookieService userCookieService)
        : base()
        {
            this.UserCookieService = userCookieService;
            this.Db = new IRunesDbContext();
        }

        protected IRunesDbContext Db { get; }

        protected bool IsAuthenticated()
        {
            return Request.Session.ContainsParameter(Common.formUsername);
        }

        protected void SignInUSer(string username, IHttpRequest request)
        {
            var userCookie = new HttpCookie(Common.authenticatingCookie,
                this.UserCookieService.GetUserCookie(username));

            request.Session.AddParameter(Common.formUsername, username);
            request.Cookies.Add(userCookie);
        }

        protected void SettingViewsBasedOnAccess()
        {
            if (!IsAuthenticated())
            {
                this.ViewModel.Data[Common.LayoutPlaceHolderError] = "none";
                this.ViewModel.Data[Common.LayoutPlaceHolderErrorMessage] = "none";
                this.ViewModel.Data[Common.LayoutPlaceHolderAuthentication] = "none";
                this.ViewModel.Data[Common.LayoutPlaceHolderNotAuthenticated] = "inline";
            }
            else
            {
                this.ViewModel.Data[Common.LayoutPlaceHolderError] = "none";
                this.ViewModel.Data[Common.LayoutPlaceHolderErrorMessage] = "none";
                this.ViewModel.Data[Common.LayoutPlaceHolderAuthentication] = "inline";
                this.ViewModel.Data[Common.LayoutPlaceHolderNotAuthenticated] = "none";
            }

            if (this.Error == null) return;
            this.ViewModel.Data[Common.LayoutPlaceHolderError] = "inline";
            this.ViewModel.Data[Common.LayoutPlaceHolderErrorMessage] = this.Error;
        }
    }
}