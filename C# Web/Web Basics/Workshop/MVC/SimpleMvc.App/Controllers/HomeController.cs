namespace SimpleMvc.App.Controllers
{
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Contracts;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("about");
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
    }
}