namespace SIS.FRAMEWORK.Routers
{
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Attributes;
    using SIS.FRAMEWORK.Controllers;
    using SIS.FRAMEWORK.Utilities;
    using SIS.HTTP.Contracts;
    using SIS.HTTP.Enums;
    using SIS.WEBSERVER.Api;
    using SIS.WEBSERVER.Results;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ControllerRouter : IHandleable
    {
        private Controller GetController(string controllerName, IHttpRequest httpRequest)
        {
            if (controllerName != null)
            {
                var controllerTypeName = string.Format(
                    "{0}.{1}.{2}{3}, {0}",
                    FrameworkContext.Get.AssemblyName,
                    FrameworkContext.Get.ControllersFolder,
                    controllerName,
                    FrameworkContext.Get.ControllerSuffix
                    );

                Type type = Type.GetType(controllerTypeName);
                var controller = (Controller)Activator.CreateInstance(type);

                if (controller == null)
                {
                    return null;
                }

                return (controller);
            }

            return null;
        }

        private MethodInfo GetMethod(string requestMethod, Controller controller, string actionName)
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in GetSuitableMethods(controller, actionName))
            {
                IEnumerable<HttpMethodAttribute> attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>();

                if (!attributes.Any() && requestMethod == "GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(m => m.Name.ToLower() == actionName.ToLower());
        }

        private IHttpResponse PrepareResponse(Controller controller, MethodInfo action)
        {
            IActionResult actionResult = (IActionResult)action.Invoke(controller, null);
            string invocationResult = actionResult.Invoke();

            if (actionResult is IViewable)
            {
                return new HtmlResult(invocationResult, HttpStatusCode.OK);
            }
            else if (actionResult is IRedirectable)
            {
                return new RedirectResult(invocationResult);
            }
            else
            {
                throw new InvalidOperationException("The view result it's not supported!");
            }
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            var requestMethod = request.RequestMethod.ToString();

            string[] invocationString = request.Path.Split('/', StringSplitOptions.RemoveEmptyEntries);

            string controllerName = string.Empty;
            string actionName = string.Empty;

            if (invocationString.Length == 0)
            {
                controllerName = "Home";
                actionName = "Index";
            }
            else if (invocationString.Length == 1)
            {
                controllerName = "Home";
                actionName = invocationString[0].Capitalize();
            }
            else if (invocationString.Length == 2)
            {
                controllerName = invocationString[0].Capitalize();
                actionName = invocationString[1].Capitalize();
            }
            else
            {
                throw new InvalidOperationException("Invalid URL");
            }

            Controller controller = this.GetController(controllerName, request);

            if (controller == null)
            {
                throw new InvalidOperationException("Controller error");
            }

            MethodInfo action = this.GetMethod(requestMethod, controller, actionName);

            if (action == null)
            {
                throw new InvalidOperationException("Route error");
            }


            try
            {
                IHttpResponse response = this.PrepareResponse(controller, action);
                return response;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}