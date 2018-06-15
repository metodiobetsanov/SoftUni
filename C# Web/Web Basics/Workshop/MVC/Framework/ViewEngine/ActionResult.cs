namespace Framework.ViewEngine
{
    using Interfaces;
    using System;

    public class ActionResult : IActionResult
    {
        public ActionResult(string fullyQualifedViewName)
        {
            this.Action = (IRenderable)Activator
                                .CreateInstance(Type.GetType(fullyQualifedViewName));
        }

        public IRenderable Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}