namespace SIS.HTTP.Requests
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Contracts;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Headers;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public IHttpSession Session { get; set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private bool IsValidRequestLine(string[] requestLine)
        {
            return requestLine.Length == 3 && requestLine[2].ToLower() == "http/1.1";
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParamaters)
        {
            return !string.IsNullOrEmpty(queryString) && queryParamaters.Any();
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            string method = requestLine.First();
            HttpRequestMethod parsedMethod;

            if (!Enum.TryParse(method, true, out parsedMethod))
            {
                throw new BadRequestException();
            }

            this.RequestMethod = parsedMethod;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            this.Path = this.Url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        private void ParseHeaders(string[] requesContent)
        {
            var emptyLineAfterHeadersIndex = Array.IndexOf(requesContent, string.Empty);

            for (int i = 0; i < emptyLineAfterHeadersIndex; i++)
            {
                var currentLine = requesContent[i];
                var headerParts = currentLine.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                if (headerParts.Length != 2)
                {
                    throw new BadRequestException();
                }

                var headerKey = headerParts[0].Trim();
                var headerValue = headerParts[1].Trim();

                var header = new HttpHeader(headerKey, headerValue);

                this.Headers.Add(header);
            }

            if (!this.Headers.ContainsHeader(HttpHeader.Host))
            {
                throw new BadRequestException("No Host Header");
            }
        }

        private void ParseCookies()
        {
            if (this.Headers.ContainsHeader(HttpHeader.Cookie))
            {
                var cookies = this.Headers.GetHeader(HttpHeader.Cookie);

                if (!cookies.Value.Contains('='))
                {
                    return;
                }

                string[] cookieParts = cookies
                    .Value
                    .Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!cookieParts.Any())
                {
                    return;
                }

                foreach (var cookiePart in cookieParts)
                {
                    string[] cookieKeyValuePair = cookiePart
                        .Split(new[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);

                    var key = cookieKeyValuePair[0].Trim();
                    var value = cookieKeyValuePair[1].Trim();

                    this.Cookies.Add(new HttpCookie(key, value, false));
                }
            }
        }

        private void ParseQueryParameters()
        {
            if (!this.Url.Contains('?'))
            {
                return;
            }

            var query = this.Url
                .Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries)
                .Last();
            if (string.IsNullOrEmpty(query))
            {
                return;
            }

            var queryPairs = query.Split(new[] { '&' });

            if (!this.IsValidRequestQueryString(query, queryPairs))
            {
                throw new BadRequestException();
            }

            foreach (var queryPair in queryPairs)
            {
                var queryKvp = queryPair.Split(new[] { '=' });

                if (queryKvp.Length != 2)
                {
                    return;
                }

                var queryKey = WebUtility.UrlDecode(queryKvp[0]);
                var queryValue = WebUtility.UrlDecode(queryKvp[1]);

                this.QueryData.Add(queryKey, queryValue);
            }
        }

        private void ParseFormDataParameters(string formData)
        {
            if (!formData.Contains('='))
            {
                return;
            }

            var formDataPairs = formData.Split(new[] { '&' });

            foreach (var formDataPair in formDataPairs)
            {
                var formDataKvp = formDataPair.Split(new[] { '=' });

                if (formDataKvp.Length != 2)
                {
                    return;
                }

                var formDataKey = WebUtility.UrlDecode(formDataKvp[0]);
                var formDataValue = WebUtility.UrlDecode(formDataKvp[1]);

                this.FormData.Add(formDataKey, formDataValue);
            }
        }

        private void ParseRequestParameters(string requestParameters)
        {
            this.ParseQueryParameters();
            this.ParseFormDataParameters(requestParameters);
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0]
                .Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                .AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {this.RequestMethod}")
                .AppendLine(this.Headers.ToString());

            if (this.Cookies.HasCookies())
            {
                foreach (var httpCookie in this.Cookies)
                {
                    result.AppendLine($"Set-Cookie: {httpCookie}");
                }
            }

            result.AppendLine();

            return result.ToString();
        }
    }
}