namespace SIS.FRAMEWORK.ActionResults.Contacts
{
    public interface IViewable : IActionResult
    {
        IRenderable View { get; set; }
    }
}