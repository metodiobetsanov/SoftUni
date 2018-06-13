namespace Framework.Controllers
{
    using Interfaces;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}