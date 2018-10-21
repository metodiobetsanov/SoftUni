

namespace IRunes.Controllers
{
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Attributes.Methods;
    using SIS.FRAMEWORK.Services.Contracts;
    using IRunes.Common;
    public class HomeController : BaseController
    {
        public HomeController(IUserCookieService userCookieService)
            : base(userCookieService)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            this.SettingViewsBasedOnAccess();
            if (IsAuthenticated())
            {
                this.ViewModel.Data[Common.formUsername] =
                    this.Request.Session.Get(Common.formUsername).ToString();
            }
            return this.View();
        }
    }
}