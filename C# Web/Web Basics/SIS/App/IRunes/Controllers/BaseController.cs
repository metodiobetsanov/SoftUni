namespace IRunes.Controllers
{
    using IRunes.Data;
    using SIS.FRAMEWORK.Controllers;
    using SIS.FRAMEWORK.Services.Contracts;

    public abstract class BaseController : Controller
    {
        protected IUserCookieService UserCookieService { get; }

        protected BaseController(IUserCookieService userCookieService)
        : base()
        {
            this.UserCookieService = userCookieService;
            this.Context = new IRunesDbContext();
        }

        protected IRunesDbContext Context { get; }

        protected void Check()
        {
            var user = this.Identity();
            if (user != null)
            {
                this.Model["IsAuthenticated"] = "inline";
                this.Model["IsNotAuthenticated"] = "none";
            }
            else
            {
                this.Model["IsAuthenticated"] = "none";
                this.Model["IsNotAuthenticated"] = "inline";
            }
        }
    }
}