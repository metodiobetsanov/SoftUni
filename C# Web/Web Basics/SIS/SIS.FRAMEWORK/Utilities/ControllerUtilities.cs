namespace SIS.FRAMEWORK.Utilities
{
    public static class ControllerUtilities
    {
        public static string GetControllerName(object controller)
            => controller.GetType()
                .Name
                .Replace(FrameworkContext.Get.ControllerSuffix, string.Empty);

        public static string GetViewFullyQualifiedName(string controller, string action)
            => string.Format("../../../{0}/{1}/{2}.html",
                FrameworkContext.Get.ViewsFolder,
                controller,
                action);
    }
}