﻿namespace IRunes.Controllers
{
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Attributes.Methods;
    using SIS.FRAMEWORK.Services.Contracts;

    public class HomeController : BaseController
    {
        public HomeController(IUserCookieService userCookieService)
            : base(userCookieService)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            this.Check();
            return this.View();
        }
    }
}