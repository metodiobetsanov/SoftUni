namespace SIS.FRAMEWORK.Views
{
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;

        private readonly string fullyQualifiedLayoutName;

        private readonly IDictionary<string, object> viewData;

        public View(string fullyQualifiedTemplateName, string fullyQualifiedLayoutName, IDictionary<string, object> viewData)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
            this.fullyQualifiedLayoutName = fullyQualifiedLayoutName;
            this.viewData = viewData;
        }

        private string ReadLayout()
        {
            if (!File.Exists(this.fullyQualifiedLayoutName))
            {
                return ($"File '{this.fullyQualifiedLayoutName}' not found");
            }

            return File.ReadAllText(this.fullyQualifiedLayoutName);
        }

        private string ReadFile()
        {
            if (!File.Exists(this.fullyQualifiedTemplateName))
            {
                return ($"File '{this.fullyQualifiedTemplateName}' not found");
            }

            return File.ReadAllText(this.fullyQualifiedTemplateName);
        }

        private string RenderHtml()
        {
            string renderedLayout = this.ReadLayout();
            string renderedHtml = this.ReadFile();

            string fullHtml = renderedLayout.Replace("@RenderBody", renderedHtml);

            if (this.viewData.Any())
            {
                foreach (var parameter in this.viewData)
                {
                    fullHtml = fullHtml
                        .Replace($"{parameter.Key}", parameter.Value.ToString());
                }
            }

            return fullHtml;
        }

        public string Render()
        {
            return this.RenderHtml();
        }
    }
}