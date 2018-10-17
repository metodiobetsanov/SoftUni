namespace SIS.FRAMEWORK.Controllers
{
    using SIS.FRAMEWORK.ActionResults;
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Utilities;
    using SIS.FRAMEWORK.Views;
    using SIS.HTTP.Contracts;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected Controller()
        {
        }

        public IHttpRequest Request { get; set; }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            var controllerName = ControllerUtilities
                .GetControllerName(this);

            var fullyQualifiedName = ControllerUtilities
                .GetViewFullyQualifiedName(controllerName, caller);

            var view = new View(fullyQualifiedName);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl) 
            => new RedirectResult(redirectUrl);
    }
}