


namespace TORSHIA.Controllers
{
    using System.Runtime.CompilerServices;
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Controllers;

    public class BaseController : Controller
    {
        protected override IViewable View([CallerMemberName] string actionName = "")
        {
            if (this.Identity != null)
            {
                this.Model.Data["LoggedIn"] = "block";
                this.Model.Data["User"] = "block";
                this.Model.Data["Admin"] = "none";
                this.Model.Data["Username"] = this.Identity.Username;
                this.Model.Data["NotLoggedIn"] = "none";
                if (this.Identity.Roles.Contains("Admin"))
                {
                    this.Model.Data["User"] = "none";
                    this.Model.Data["Admin"] = "block";
                }
            }
            else
            {
                this.Model.Data["LoggedIn"] = "none";
                this.Model.Data["NotLoggedIn"] = "block";
            }

            return base.View(actionName);
        }
    }
}
