namespace Framework.ViewEngine.Generic
{
    using Interfaces;
    using Interfaces.Generic;
    using System;

    public class ActionResult<T> : IActionResult<T>
    {
        public ActionResult(string fullyQualifedViewName, T model)
        {
            this.Action = (IRenderable<T>)Activator.CreateInstance(Type.GetType(fullyQualifedViewName));

            this.Action.Model = model;
        }

        public IRenderable<T> Action { get; set; }


        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}