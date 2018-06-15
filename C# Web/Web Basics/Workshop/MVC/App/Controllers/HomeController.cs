namespace App.Controllers
{
    using Framework.Attributes.Methods;
    using Framework.Controllers;
    using Framework.Interfaces;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}