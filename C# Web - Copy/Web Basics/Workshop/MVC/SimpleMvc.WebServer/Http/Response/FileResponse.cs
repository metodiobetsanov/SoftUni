

namespace SimpleMvc.WebServer.Http.Response
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SimpleMvc.WebServer.Enums;
    using SimpleMvc.WebServer.Exceptions;
    using SimpleMvc.WebServer.Http.Contracts;

    public class FileResponse : HttpResponse
    {
        public FileResponse(HttpStatusCode httpStatusCode, byte[] fileData)
        {
            this.ValidateStatusCode(StatusCode);

            this.FileData = fileData;
            this.StatusCode = httpStatusCode;

            this.Headers.Add(HttpHeader.ContentLenght, this.FileData.Length.ToString());
            this.Headers.Add(HttpHeader.ContentDisposition,"attachment");
        }

        private void ValidateStatusCode(HttpStatusCode httpStatusCode)
        {
            var statusCode = (int)httpStatusCode;

            if (299 > statusCode && statusCode < 400)
            {
                throw new InvalidResponseException("File responses need a status code above 300 and below 400.");
            }
        }

        public byte[] FileData { get; }
    }
}
