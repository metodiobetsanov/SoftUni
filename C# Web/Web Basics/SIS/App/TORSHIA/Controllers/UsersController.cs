namespace TORSHIA.Controllers
{
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Attributes.Methods;
    using SIS.FRAMEWORK.Security;
    using System.Collections.Generic;
    using TORSHIA.Models;
    using TORSHIA.Services.Contracts;
    using TORSHIA.ViewModels;

    public class UsersController : BaseController
    {
        private IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            User user = this.usersService.LoginUser(model);

            if (user == null)
            {
                return this.Login();
            }

            this.SignIn(new IdentityUser
            {
                Id = user.Id.ToString(),
                Username = user.Username,
                Email = user.Email,
                Roles = new List<string>() { user.Role.ToString() }
            });

            return this.RedirectToAction("/");
        }

        [HttpGet]
        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            User user = this.usersService.RegisterUser(model);

            if (user == null)
            {
                return this.Register();
            }

            this.SignIn(new IdentityUser
            {
                Id = user.Id.ToString(),
                Username = user.Username,
                Email = user.Email,
                Roles = new List<string>() { user.Role.ToString() }
            });

            return this.RedirectToAction("/");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.SignOut();

            return this.RedirectToAction("/");
        }
    }
}