namespace IRunes.Controllers
{
    using IRunes.Services.Contracts;
    using IRunes.ViewModels;
    using SIS.FRAMEWORK.ActionResults;
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Attributes.Methods;
    using SIS.FRAMEWORK.Services.Contracts;

    public class UsersController : BaseController
    {
        public UsersController(IUserService userService, IUserCookieService userCookieService) : base(userCookieService)
        {
            this.UserService = userService;
        }

        protected IUserService UserService { get; }

        [HttpGet]
        public IActionResult Register()
        {
            this.SettingViewsBasedOnAccess();
            return this.View();
        }
        
        [HttpPost]
        public IActionResult Register(Register model)
        {
            var success = this.UserService.RegisterUser(model);
            if (success)
            {
                string username = model.Username;
                var result = new RedirectResult("/");
                this.SignInUSer(username, this.Request);
                return result;
            }

            return this.Register();
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            this.SettingViewsBasedOnAccess();
            return this.View();
        }
        
        [HttpPost]
        public IActionResult Login(Login model)
        {
            var userFromDb = this.UserService.GetUser(model);
            if (userFromDb != null)
            {
                this.SignInUSer(userFromDb.Username, this.Request);
                return this.RedirectToAction("/");
            }

            this.Error = "User credentials are not correct!";

            this.SettingViewsBasedOnAccess();
            return this.Login();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.Request.Session.Clear();

            return this.RedirectToAction("/");
        }
    }
}