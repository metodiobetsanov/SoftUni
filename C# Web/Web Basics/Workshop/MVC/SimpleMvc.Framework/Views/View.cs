namespace SimpleMvc.Framework.Views
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using SimpleMvc.Framework.Contracts;
    using SimpleMvc.Framework.Common;

    public class View : IRenderable
    {
        public const string BaseLayoutFileName = "Layout";

        public const string ContentPlaceholder = "{{{content}}}";

        public const string FileExtension = ".html";

        public const string LocalErrorPath = "\\SimpleMvc.Framework\\Errors\\Error.html";

        private readonly string templateFullQualifiedName;

        private readonly IDictionary<string, string> viewData;

        public View(string templateFullQualifiedName, IDictionary<string, string> viewData)
        {
            this.templateFullQualifiedName = templateFullQualifiedName;
            this.viewData = viewData;
        }

        public string Render()
        {
            var fileHtml = this.ReadFile();

            if (this.viewData.Any())
            {
                foreach (var viewParam in this.viewData)
                {
                    fileHtml = fileHtml.Replace($"{{{{{{{viewParam.Key}}}}}}}", viewParam.Value);
                }
            }

            return fileHtml;
        }

        private string ReadFile()
        {
            var layoutHtml = this.RenderLayoutHtml();

            var templateFullFilePath = string.Format(
                "{0}\\{1}{2}",
                LocalPathInfo.LocalPath,
                this.templateFullQualifiedName,
                FileExtension
                );

            if (!File.Exists(templateFullFilePath))
            {
                this.viewData["error"] = $"The requested view ({templateFullFilePath}) could not be found!";
                return this.GetErrorHtml();
            }

            var templateHtml = File.ReadAllText(templateFullFilePath);

            return layoutHtml.Replace(ContentPlaceholder, templateHtml);
        }

        private string RenderLayoutHtml()
        {
            var layoutHtmlFile = string.Format(
                "{0}\\{1}\\{2}\\{3}{4}",
                LocalPathInfo.LocalPath,
                Context.Get.AssemblyName,
                Context.Get.ViewsFolder,
                BaseLayoutFileName,
                FileExtension);

            if (!File.Exists(layoutHtmlFile))
            {
                this.viewData["error"] = $"Layout view ({layoutHtmlFile}) could not be found!";
                return this.GetErrorHtml();
            }

            return File.ReadAllText(layoutHtmlFile);
        }

        private string GetErrorPath()
        {
            //var currentDirectory = Directory.GetCurrentDirectory();
            //var parentDirectory = Directory.GetParent(currentDirectory);
            //var parentDirectoryPath = parentDirectory.FullName;

            return $"{LocalPathInfo.LocalPath}{LocalErrorPath}";
        }

        private string GetErrorHtml()
        {
            var errorPath = this.GetErrorPath();
            var errorHtml = File.ReadAllText(errorPath);
            return errorHtml;
        }
    }
}