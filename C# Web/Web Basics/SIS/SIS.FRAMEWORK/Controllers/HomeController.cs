

namespace SIS.FRAMEWORK.Controllers
{
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
