namespace Framework.Views.Home
{
    using Interfaces;

    public class Index : IRenderable
    {
        public string Render()
        {
            return "<h1>Welcome</h1>";
        }
    }
}