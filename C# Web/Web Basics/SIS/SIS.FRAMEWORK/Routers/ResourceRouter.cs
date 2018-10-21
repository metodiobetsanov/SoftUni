namespace SIS.FRAMEWORK.Routers
{
    using SIS.HTTP.Contracts;
    using SIS.HTTP.Enums;
    using SIS.WEBSERVER.Api;
    using SIS.WEBSERVER.Results;
    using System;
    using System.IO;
    using System.Linq;

    public class ResourceRouter : IHandleable
    {
        private const string relativePath = "../../../";

        public IHttpResponse Handle(IHttpRequest request)
        {
            string fileFullName = request.Path.Split('/').Last();
            string fileExtension = request.Path.Split('.').Last();

            try
            {
                byte[] fileContent = this.ReadFileContent(fileFullName, fileExtension);

                return new InlineResourceResult(fileContent, HttpStatusCode.Found);
            }
            catch (Exception e)
            {
                return new NotFoundResult(e.Message, HttpStatusCode.NotFound);
            }
        }

        private byte[] ReadFileContent(string fileFullName, string fileExtension)
        {
            byte[] byteContent = File.ReadAllBytes(
                string.Format(
                    "{0}//{1}//{2}//{3}",
                    relativePath,
                    FrameworkContext.Get.ResourcesFolder,
                    fileExtension,
                    fileFullName
                    )
                );

            return byteContent;
        }
    }
}