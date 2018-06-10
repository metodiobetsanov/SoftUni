namespace WebServer.Server.HTTP.Request
{
    using Contracts;
    using Enums;
    using Exceptions;
    using HTTP;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, string>();
            this.HeaderCollection = new HttpHeaderCollection();
            this.QueryParameters = new Dictionary<string, string>();
            this.UrlParameters = new Dictionary<string, string>();

            this.ParseRequest(requestString);
        }

        public IDictionary<string, string> FormData { get; private set; }

        public IHttpHeaderCollection HeaderCollection { get; private set; }

        public string Path { get; private set; }

        public IDictionary<string, string> QueryParameters { get; private set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public string Url { get; private set; }

        public IDictionary<string, string> UrlParameters { get; private set; }

        public void AddUrlParameters(string key, string value)
        {
            this.UrlParameters[key] = value;
        }

        private void ParseRequest(string requestString)
        {
            string[] requestLines = requestString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string[] requestLine = requestLines.First().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (requestLine.Length != 3 || requestLine[2].ToLower() != "http/1.1")
            {
                throw new BadRequestException();
            }

            this.RequestMethod = this.ParseRequestMethod(requestLine[0].ToUpper());

            this.Url = requestLine[1];

            this.Path = this.Url.Split(new[] { "?", "#" }, StringSplitOptions.RemoveEmptyEntries)[0];

            this.ParseHeaders(requestLines);

            this.ParseParametars();

            if (this.RequestMethod == HttpRequestMethod.POST)
            {
                this.ParseQuery(requestLines[requestLines.Length - 1], this.FormData);
            }
        }

        private void ParseParametars()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }

            string query = this.Url.Split(new[] { "?" }, StringSplitOptions.RemoveEmptyEntries)[1];

            this.ParseQuery(query, this.QueryParameters);
        }

        private void ParseQuery(string query, IDictionary<string, string> dict)
        {
            if (!query.Contains("="))
            {
                return;
            }

            string[] queryPairs = query.Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string queryPair in queryPairs)
            {
                string[] args = queryPair.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);

                if (args.Length != 2)
                {
                    continue;
                }

                dict.Add(
                    WebUtility.UrlDecode(args[0]),
                    WebUtility.UrlDecode(args[1])
                    );
            }
        }

        private void ParseHeaders(string[] requestLines)
        {
            int indexOfEmptyLine = Array.IndexOf(requestLines, Environment.NewLine);

            for (int i = 1; i < indexOfEmptyLine; i++)
            {
                string[] headerLine = requestLines[i].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                HttpHeader header = new HttpHeader(headerLine[0], headerLine[1].Trim());
                this.HeaderCollection.Add(header);
            }
        }

        private HttpRequestMethod ParseRequestMethod(string v)
        {
            if (Enum.TryParse<HttpRequestMethod>(v, out HttpRequestMethod result))
            {
                return result;
            }
            else
            {
                throw new BadRequestException($"Invalid HTTP Method: {v}");
            }
        }
    }
}