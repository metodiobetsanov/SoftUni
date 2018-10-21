
namespace SimpleMvc.Framework.Routers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using SimpleMvc.Framework.Common;
    using SimpleMvc.WebServer.Contracts;
    using SimpleMvc.WebServer.Enums;
    using SimpleMvc.WebServer.Http.Contracts;
    using SimpleMvc.WebServer.Http.Response;

    public class ResourceRouter : IHandleable
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            string fileFullName = request.Path.Split('/').Last();
            string fileExtension = request.Path.Split('.').Last();

            IHttpResponse fileResponse = null;

            try
            {
                byte[] fileContent = this.ReadFileContent(fileFullName, fileExtension);

                fileResponse = new FileResponse(HttpStatusCode.Found, fileContent);
            }
            catch (Exception)
            {
                return new NotFoundResponse();
            }

            return fileResponse;
        }

        private byte[] ReadFileContent(string fileFullName, string fileExtension)
        {
            byte[] byteContent = File.ReadAllBytes(
                string.Format(
                    "{0}//{1}//{2}//{3}//{4}",
                    LocalPathInfo.LocalPath,
                    Context.Get.AssemblyName,
                    Context.Get.ResourcesFolder,
                    fileExtension,
                    fileFullName
                    )
                );

            return byteContent;
        }
    }
}
