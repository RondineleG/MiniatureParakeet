using System.Net;

namespace MiniatureParakeet.Api.Configurations
{
    public class HttpResponseException : Exception
    {
        public int StatusCodeException { get; set; } = 500;

        public object ResponseAlert { get; set; }

        public HttpResponseException(string errorMessage, HttpStatusCode httpStatusCode)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(httpStatusCode)
            {
                Content = new StringContent(errorMessage, System.Text.Encoding.UTF8, "text/plain"),
                ReasonPhrase = errorMessage,
                StatusCode = httpStatusCode
            };

            StatusCodeException = Convert.ToInt32(httpStatusCode);

            ResponseAlert = httpResponseMessage;
        }
    }
}
