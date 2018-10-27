namespace SIS.FRAMEWORK.Controllers
{
    using SIS.FRAMEWORK.ActionResults;
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Models;
    using SIS.FRAMEWORK.Security.Contracts;
    using SIS.FRAMEWORK.Utilities;
    using SIS.FRAMEWORK.Views;
    using SIS.HTTP.Contracts;
    using System.IO;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        private ViewEngine ViewEngine { get; }

        protected Controller()
        {
            this.ViewEngine = new ViewEngine();

            this.ModelState = new Model();
            this.Model = new ViewModel();
        }

        public Model ModelState { get; }

        public IHttpRequest Request { get; set; }

        public ViewModel Model { get; set; }

        public IIdentity Identity
            => this.Request.Session.ContainsParameter("auth")
                ? (IIdentity)this.Request.Session.Get("auth")
                : null;

        protected virtual IViewable View([CallerMemberName] string actionName = "")
        {
            var controllerName = ControllerUtilities.GetControllerName(this);

            string viewContent = null;

            try
            {
                viewContent = this.ViewEngine.GetViewContent(controllerName, actionName);
            }
            catch (FileNotFoundException e)
            {
                this.Model.Data["Error"] = e.Message;
                viewContent = this.ViewEngine.GetErrorContent();
            }

            string renderedContent = this.ViewEngine.RenderHtml(viewContent, this.Model.Data);
            return new ViewResult(new View(renderedContent));
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
            => new RedirectResult(redirectUrl);

        protected void SignIn(IIdentity auth)
        {
            this.Request.Session.AddParameter("auth", auth);
        }

        protected void SignOut()
        {
            this.Request.Session.Clear();
        }

        
    }
}