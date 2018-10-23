namespace IRunes.Controllers
{
    using IRunes.Services.Contracts;
    using SIS.FRAMEWORK.Security;
    using IRunes.ViewModels;
    using SIS.FRAMEWORK.ActionResults;
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Attributes.Methods;
    using SIS.FRAMEWORK.Services.Contracts;

    public class UsersController : BaseController
    {
        private IUserService UserService { get; }

        public UsersController(IUserService userService, IUserCookieService userCookieService)
            : base(userCookieService)
        {
            this.UserService = userService;
        }

        
        [HttpGet]
        public IActionResult Login()
        {
            this.Check();
            return this.View();
        }
        
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = this.UserService.GetUser(model);
            if (user != null)
            {
                this.SignIn(new IdentityUser() { Username = model.Username, Password = model.Password});
                return this.RedirectToAction("/");
            }

            return this.Login();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.SignOut();

            return new RedirectResult("/");
        }

        [HttpGet]
        public IActionResult Register()
        {
            this.Check();
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var success = this.UserService.RegisterUser(model);
            if (success)
            {
                return this.RedirectToAction("/");
            }

            return this.Register();
        }
    }
}