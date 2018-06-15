namespace Framework.Routers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Framework.Attributes.Methods;
    using Framework.Common;
    using Framework.Controllers;
    using Framework.Interfaces;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParams;
        private IDictionary<string, string> postParams;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private object[] actionParams;

        public ControllerRouter()
        {
            this.getParams = new Dictionary<string, string>();
            this.postParams = new Dictionary<string, string>();
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            this.getParams = request.UrlParameters;

            this.postParams = request.FormData;

            this.requestMethod = request.Method.ToString();

            string[] invocationString = request.Path.Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (invocationString.Length != 2)
            {
                throw new InvalidOperationException("Invalid URL");
            }

            this.controllerName = invocationString[0].CapitalizeFirstLetter() + Context.Get.ControllersSuffix;
            this.actionName = invocationString[1].CapitalizeFirstLetter(); ;

            MethodInfo action = this.GetMethod();

            if (action == null)
            {
                return new NotFoundResponse();
            }

            var parameters = action.GetParameters();

            this.actionParams = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];

                if (param.ParameterType.IsPrimitive || param.ParameterType == typeof(string))
                {
                    object value = this.getParams[param.Name];
                    this.actionParams[i] = Convert.ChangeType(
                        value,
                        param.ParameterType
                        );
                }
                else
                {
                    Type bindingModelType = param.ParameterType;

                    object bindingModel = Activator.CreateInstance(bindingModelType);

                    IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

                    foreach (PropertyInfo property in properties)
                    {
                        property.SetValue(
                            bindingModel,
                            Convert.ChangeType(
                                this.postParams[property.Name],
                                property.PropertyType
                                )
                            );
                    }

                    this.actionParams[i] = Convert.ChangeType(
                        bindingModel,
                        bindingModelType
                        );
                }
            }

            IInvocable actionResult = (IInvocable)action
                .Invoke(this.GetController(), this.actionParams);

            string content = actionResult.Invoke();

            IHttpResponse response = new ContentResponse(HttpStatusCode.Ok, content);

            return response;
        }

        private MethodInfo GetMethod()
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in this.GetSuitibleMethods())
            {
                IEnumerable<Attribute> attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute);

                if (!attributes.Any() && this.requestMethod == "GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(this.requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitibleMethods()
        {
            var controller = this.GetController();

            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller.GetType().GetMethods().Where(m => m.Name == this.actionName);
        }

        private Controller GetController()
        {
            var controllerFullyQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                Context.Get.AssemblyName,
                Context.Get.ControllersFolder,
                this.controllerName
                );

            Type type = Type.GetType(controllerFullyQualifiedName);

            if (type == null)
            {
                return null;
            }

            return (Controller)Activator.CreateInstance(type);
        }
    }
}