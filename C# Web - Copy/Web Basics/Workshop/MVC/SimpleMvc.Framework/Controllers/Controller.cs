namespace SimpleMvc.Framework.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using ActionResults;

    using Attributes.Properties;

    using Contracts;

    using Models;
    using SimpleMvc.Framework.Security;
    using SimpleMvc.WebServer.Http;
    using SimpleMvc.WebServer.Http.Contracts;
    using Views;

    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
            this.User = new Authentication();
        }

        protected ViewModel Model;

        protected internal IHttpRequest  Request { get; internal set; }

        public Authentication User { get; private set; }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            string controller = this.GetType()
                .Name
                .Replace(Context.Get.ControllerSuffix, string.Empty);

            string fullyQualifiedName = string.Format(
                "{0}\\{1}\\{2}\\{3}",
                Context.Get.AssemblyName,
                Context.Get.ViewsFolder,
                controller,
                caller
                );

            IRenderable view = new View(fullyQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }

        protected internal void InitializeController()
        {
            var user = this.Request.Session.Get<string>(SessionStore.CurrentUserKey);

            if (user != null)
            {
                this.User = new Authentication(user);
            }
        }

        protected void SignIn(string name)
        {
            this.Request.Session.Add(SessionStore.CurrentUserKey, name);
        }

        protected void SignOut()
        {
            this.Request.Session.Clear();
        }

        protected bool IsValidModel(object bidingModel)
        {
            foreach (var property in bidingModel.GetType().GetProperties())
            {
                IEnumerable<Attribute> attributes = property
                    .GetCustomAttributes()
                    .Where(a => a is PropertyAttribute);

                if (!attributes.Any())
                {
                    continue;
                }

                foreach (PropertyAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(bidingModel)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}