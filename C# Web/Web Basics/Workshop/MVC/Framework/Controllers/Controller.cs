namespace Framework.Controllers
{
    using Interfaces;
    using Interfaces.Generic;
    using ViewEngine;
    using ViewEngine.Generic;

    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string caller = "")
        {
            string controller = this.GetType()
                .Name
                .Replace(Context.Get.ControllersSuffix, string.Empty);

            string fullyQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}, {0}",
                Context.Get.AssemblyName,
                Context.Get.ViewsFolder,
                controller,
                caller
                );

            return new ActionResult(fullyQualifiedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName] string caller = "")
        {
            string controller = this.GetType()
                .Name
                .Replace(Context.Get.ControllersSuffix, string.Empty);

            string fullyQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}, {0}",
                Context.Get.AssemblyName,
                Context.Get.ViewsFolder,
                controller,
                caller
                );

            return new ActionResult<T>(fullyQualifiedName, model);
        }

        protected IActionResult View(string controller, string action)
        {
            string fullyQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}, {0}",
                Context.Get.AssemblyName,
                Context.Get.ViewsFolder,
                controller,
                action
                );

            return new ActionResult(fullyQualifiedName);
        }

        protected IActionResult<T> View<T>(T model, string controller, string action)
        {
            string fullyQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}, {0}",
                Context.Get.AssemblyName,
                Context.Get.ViewsFolder,
                controller,
                action
                );

            return new ActionResult<T>(fullyQualifiedName, model);
        }
    }
}