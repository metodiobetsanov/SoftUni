namespace SIS.FRAMEWORK.Controllers
{
    using SIS.FRAMEWORK.ActionResults;
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Models;
    using SIS.FRAMEWORK.Utilities;
    using SIS.FRAMEWORK.Views;
    using SIS.HTTP.Contracts;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected Controller()
        {
            this.ViewModel = new ViewModel();
        }

        public Model ModelState { get; } = new Model();

        public IHttpRequest Request { get; set; }

        public ViewModel ViewModel { get; set; }

        protected IViewable View([CallerMemberName] string viewName = "")
        {
            var controllerName = ControllerUtilities.GetControllerName(this);

            var viewFullyQualifiedName = ControllerUtilities
                .GetViewFullyQualifiedName(controllerName, viewName);

            var fullyQualifiedTemplateName = ControllerUtilities.GetLayoutFullyQualifiedName();

            var view = new View(viewFullyQualifiedName, fullyQualifiedTemplateName, this.ViewModel.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
            => new RedirectResult(redirectUrl);
    }
}