namespace App.Views.Home
{
    using Framework.Interfaces;

    public class Index : IRenderable
    {
        public string Render()
        {
            return "<h1>Welcome</h1>";
        }
    }
}