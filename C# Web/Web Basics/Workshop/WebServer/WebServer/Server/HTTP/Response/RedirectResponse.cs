namespace WebServer.Server.HTTP.Response
{
    using Enums;
    using Contracts;

    public class ViewResponse : HttpResponse
    {
        private readonly IView View;

        public ViewResponse(HttpStatusCode statusCode, IView view)
            : base()
        {
            this.StatusCode = statusCode;
            this.View = view;
        }

        public override string ToString()
        {
            if ((int)this.StatusCode < 300 || (int)this.StatusCode > 400)
            {
                return $"{base.ToString()}{this.View.View()}";
            }

            return base.ToString();
        }
    }
}