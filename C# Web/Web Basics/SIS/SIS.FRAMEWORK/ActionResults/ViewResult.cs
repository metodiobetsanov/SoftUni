namespace SIS.FRAMEWORK.ActionResults
{
    using SIS.FRAMEWORK.ActionResults.Contacts;

    public class ViewResult : IViewable
    {
        public ViewResult(IRenderable view)
        {
            this.View = view;
        }

        public IRenderable View { get; set; }

        public string Invoke() => this.View.Render();
    }
}