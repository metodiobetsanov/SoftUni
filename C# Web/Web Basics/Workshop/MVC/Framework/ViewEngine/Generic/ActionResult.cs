namespace Framework.ViewEngine.Generic
{
    using Interfaces;
    using Interfaces.Generic;
    using System;

    public class ActionResult<T> : IActionResult<T>
    {
        public ActionResult(string viewFullQualifedName, T model)
        {
            this.Action = (IRenderable<T>)Activator.CreateInstance(Type.GetType(viewFullQualifedName));

            this.Model = model;
        }

        public IRenderable<T> Action { get; set; }

        public T Model { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}