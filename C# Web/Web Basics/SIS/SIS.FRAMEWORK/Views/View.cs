namespace SIS.FRAMEWORK.Views
{
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using System.IO;

    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;

        public View(string fullyQualifiedTemplateName)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
        }

        private string ReadFile()
        {
            if (!File.Exists(this.fullyQualifiedTemplateName))
            {
                throw new FileNotFoundException("No html file");
            }

            return File.ReadAllText(this.fullyQualifiedTemplateName);
        }

        public string Render()
        {
            return this.ReadFile();
        }
    }
}