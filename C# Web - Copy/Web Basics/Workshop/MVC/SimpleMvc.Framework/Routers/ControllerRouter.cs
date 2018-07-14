namespace SimpleMvc.Framework.Routers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Common;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Contracts;

    using SimpleMvc.WebServer.Contracts;
    using SimpleMvc.WebServer.Enums;
    using SimpleMvc.WebServer.Http.Contracts;
    using SimpleMvc.WebServer.Http.Response;

    public class ControllerRouter : IHandleable
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            IDictionary<string, string> getParams = request.UrlParameters;

            IDictionary<string, string> postParams = request.FormData;

            string requestMethod = request.Method.ToString().ToUpper();

            string[] invocationString = request.Path.Split('/', StringSplitOptions.RemoveEmptyEntries);

            string controllerName = string.Empty;
            string actionName = string.Empty;

            if (invocationString.Length == 0)
            {
                controllerName = $"Home{Context.Get.ControllerSuffix}";
                actionName = "Index";
            }
            else if (invocationString.Length == 1)
            {
                controllerName = $"Home{Context.Get.ControllerSuffix}";
                actionName = invocationString[0].CapitalizeFirstLetter();
            }
            else if (invocationString.Length == 2)
            {
                controllerName = $"{invocationString[0].CapitalizeFirstLetter()}{Context.Get.ControllerSuffix}";
                actionName = invocationString[1].CapitalizeFirstLetter();
            }
            else
            {
                throw new InvalidOperationException("Invalid URL");
            }

            Controller controller = this.GetController(controllerName);

            if (controller != null)
            {
                controller.Request = request;
                controller.InitializeController();
            }

            MethodInfo action = this.GetMethod(controller, requestMethod, actionName);

            if (action == null)
            {
                return new NotFoundResponse();
            }

            var parameters = action.GetParameters();

            object[] actionParams = this.AddParameters(parameters, getParams, postParams);

            try
            {
                IHttpResponse response = this.GetResponse(action, controller, actionParams);
                return response;
            }
            catch (Exception ex)
            {
                return new InternalServerErrorResponse(ex);
            }
        }

        private Controller GetController(string controllerName)
        {
            var controllerFullyQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                Context.Get.AssemblyName,
                Context.Get.ControllersFolder,
                controllerName
                );

            Type type = Type.GetType(controllerFullyQualifiedName);

            if (type == null)
            {
                return null;
            }

            return (Controller)Activator.CreateInstance(type);
        }

        private MethodInfo GetMethod(Controller controller, string requestMethod, string actionName)
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in this.GetSuitibleMethods(controller, actionName))
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

        private IEnumerable<MethodInfo> GetSuitibleMethods(Controller controller, string actionName)
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

        private object[] AddParameters(ParameterInfo[] parameters, IDictionary<string, string> getParams, IDictionary<string, string> postParams)
        {
            object[] methodParams = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];

                if (param.ParameterType.IsPrimitive || param.ParameterType == typeof(string))
                {
                    methodParams[i] = this.ProcessPrimitiveParameter(param, getParams);
                }
                else
                {
                    methodParams[i] = this.ProcessComplexParameter(param, postParams);
                }
            }

            return methodParams;
        }

        private object ProcessComplexParameter(ParameterInfo param, IDictionary<string, string> postParams)
        {
            Type bindingModelType = param.ParameterType;

            object bindingModel = Activator.CreateInstance(bindingModelType);

            IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                property.SetValue(
                    bindingModel,
                    Convert.ChangeType(
                        postParams[property.Name],
                        property.PropertyType
                        )
                    );
            }

            return Convert.ChangeType(bindingModel, bindingModelType);
        }

        private object ProcessPrimitiveParameter(ParameterInfo param, IDictionary<string, string> getParams)
        {
            object value = getParams[param.Name];
            return Convert.ChangeType(value, param.ParameterType);
        }

        private IHttpResponse GetResponse(MethodInfo action, Controller controller, object[] actionParams)
        {
            object actionResult = action.Invoke(controller, actionParams);

            IHttpResponse response = null;

            if (actionResult is IViewable)
            {
                string content = ((IViewable)actionResult).Invoke();

                response = new ContentResponse(HttpStatusCode.Ok, content);
            }
            else if (actionResult is IRedirectable)
            {
                string redirectUrl = ((IRedirectable)actionResult).Invoke();

                response = new RedirectResponse(redirectUrl);
            }

            return response;
        }
    }
}