namespace SIS.FRAMEWORK.Routers
{
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Attributes.Methods;
    using SIS.FRAMEWORK.Attributes.Property;
    using SIS.FRAMEWORK.Attributes.Action;
    using SIS.FRAMEWORK.Controllers;
    using SIS.FRAMEWORK.Services.Contracts;
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
        private readonly IDependencyContainer dependencyContainer;

        public ControllerRouter(IDependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            var controllerName = string.Empty;
            var actionName = string.Empty;
            var requestMethod = request.RequestMethod.ToString();

            if (request.Path == "/")
            {
                controllerName = "Home";
                actionName = "Index";
            }
            else
            {
                var requestUrlSplit = request.Path.Split("/", StringSplitOptions.RemoveEmptyEntries);

                controllerName = requestUrlSplit[0].Capitalize();
                actionName = requestUrlSplit[1].Capitalize();
            }

            var controller = this.GetController(controllerName);

            var action = this.GetAction(requestMethod, controller, actionName);

            if (controller == null || action == null)
            {
                return new NotFoundResult("Not found route", HttpStatusCode.NotFound);
            }

            controller.Request = request;

            object[] actionParameters = this.MapActionParameters(action, request, controller);

            if (!this.IsAuthorized(controller, action))
            {
                return new UnauthorizedResult();
            }

            var actionResult = this.InvokeAction(controller, action, actionParameters);

            return this.PrepareResponse(actionResult);
        }

        private bool IsAuthorized(Controller controller, MethodInfo action)
        {
            if (action.GetCustomAttributes()
                .Where(a => a is AuthorizeAttribute)
                .Cast<AuthorizeAttribute>()
                .Any(a => !a.IsAuthorized(controller.Identity())))
            {
                return false;
            }

            return true;
        }

        private Controller GetController(string controllerName)
        {
            if (string.IsNullOrWhiteSpace(controllerName))
            {
                return null;
            }

            var fullyQualifiedControllerName = string.Format("{0}.{1}.{2}{3}, {0}",
                FrameworkContext.Get.AssemblyName,
                FrameworkContext.Get.ControllersFolder,
                controllerName,
                FrameworkContext.Get.ControllerSuffix);

            var controllerType = Type.GetType(fullyQualifiedControllerName);
            var controller = (Controller)this.dependencyContainer.CreateInstance(controllerType);
            return controller;
        }

        private MethodInfo GetAction(string requestMethod, Controller controller, string actionName)
        {
            var actions = this
                .GetSuitableMethods(controller, actionName)
                .ToList();

            if (!actions.Any())
            {
                return null;
            }

            foreach (var action in actions)
            {
                var httpMethodAttributes = action
                    .GetCustomAttributes()
                    .Where(ca => ca is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>()
                    .ToList();

                if (!httpMethodAttributes.Any() &&
                    requestMethod.ToLower() == "get")
                {
                    return action;
                }

                foreach (var httpMethodAttribute in httpMethodAttributes)
                {
                    if (httpMethodAttribute.IsValid(requestMethod))
                    {
                        return action;
                    }
                }
            }

            return null;
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
                .Where(mi => mi.Name.ToLower() == actionName.ToLower());
        }

        private IHttpResponse PrepareResponse(IActionResult actionResult)
        {
            string invocationResult = actionResult.Invoke();

            if (actionResult is IViewable)
            {
                return new HtmlResult(invocationResult, HttpStatusCode.OK);
            }

            if (actionResult is IRedirectable)
            {
                return new RedirectResult(invocationResult);
            }

            throw new InvalidOperationException("Type of result is not supported");
        }

        private IActionResult InvokeAction(Controller controller, MethodInfo action, object[] actionParameters)
        {
            return (IActionResult)action.Invoke(controller, actionParameters);
        }

        private object[] MapActionParameters(MethodInfo action, IHttpRequest request, Controller controller)
        {
            var actionParameteres = action.GetParameters();
            object[] mappedActionParameters = new object[actionParameteres.Length];
            for (int i = 0; i < actionParameteres.Length; i++)
            {
                var actionParameter = actionParameteres[i];

                if (actionParameter.ParameterType.IsPrimitive ||
                    actionParameter.ParameterType == typeof(string))
                {
                    var mappedActionParameter = new object();
                    mappedActionParameter = this.ProcessPrimitiveParameter(actionParameter, request);
                    if (mappedActionParameter == null)
                    {
                        break;
                    }
                }
                else
                {
                    var bindingModel = this.ProcessesBindingModelParameter(actionParameter, request);
                    controller.ModelState.IsValid = this.IsValid(
                        bindingModel,
                        actionParameter.ParameterType);
                    mappedActionParameters[i] = bindingModel;
                }
            }

            return mappedActionParameters;
        }

        private bool? IsValid(object bindingModel, Type bindingModelType)
        {
            var properties = bindingModelType.GetProperties();

            foreach (var property in properties)
            {
                var propertyValidationAttributes = property
                    .GetCustomAttributes()
                    .Where(ca => ca is ValidationAttributes)
                    .Cast<ValidationAttributes>()
                    .ToList();

                foreach (var validationAttribute in propertyValidationAttributes)
                {
                    var propertyValue = property.GetValue(bindingModel);

                    if (!validationAttribute.IsValid(propertyValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private object ProcessPrimitiveParameter(ParameterInfo actionParameter, IHttpRequest request)
        {
            var value = this.GetParameterFromRequestData(request, actionParameter.Name);
            if (value == null)
            {
                return value;
            }
            return Convert.ChangeType(value, actionParameter.ParameterType);
        }

        private object ProcessesBindingModelParameter(ParameterInfo actionParameter, IHttpRequest request)
        {
            var bindingModelType = actionParameter.ParameterType;

            var bindingModelInstance = Activator.CreateInstance(bindingModelType);

            var bindingModelProperties = bindingModelType.GetProperties();

            foreach (var bindingModelProperty in bindingModelProperties)
            {
                try
                {
                    var value = this.GetParameterFromRequestData(
                        request,
                        bindingModelProperty.Name.UnCapitalize());

                    bindingModelProperty.SetValue(
                        bindingModelInstance,
                        Convert.ChangeType(value, bindingModelProperty.PropertyType));
                }
                catch (Exception)
                {
                    Console.WriteLine($"The property {bindingModelProperty.Name} could not be mapped");
                }
            }

            return Convert.ChangeType(bindingModelInstance, bindingModelType);
        }

        private object GetParameterFromRequestData(IHttpRequest request, string actionParameterName)
        {
            if (request.QueryData.ContainsKey(actionParameterName))
            {
                return request.QueryData[actionParameterName];
            }

            if (request.FormData.ContainsKey(actionParameterName))
            {
                return request.FormData[actionParameterName];
            }

            return null;
        }
    }
}