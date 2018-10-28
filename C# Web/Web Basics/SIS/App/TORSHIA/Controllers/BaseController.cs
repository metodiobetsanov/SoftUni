namespace TORSHIA.Controllers
{
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Controllers;
    using System.Runtime.CompilerServices;

    public class BaseController : Controller
    {
        protected override IViewable View([CallerMemberName] string actionName = "")
        {
            if (this.Identity != null)
            {
                this.Model.Data["Username"] = this.Identity.Username;
                this.Model.Data["LoggedIn"] = "block";
                this.Model.Data["NotLoggedIn"] = "none";
                this.Model.Data["UserLoggedIn"] = "block";
                this.Model.Data["AdminLoggedIn"] = "none";

                if (this.Identity.Roles.Contains("Admin"))
                {
                    this.Model.Data["UserLoggedIn"] = "none";
                    this.Model.Data["AdminLoggedIn"] = "block";
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