using Microsoft.AspNetCore.Http;

namespace Common.Services
{
    public class PathService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public PathService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetServerUrl()
        {
            HttpRequest? httpRequest = _contextAccessor.HttpContext.Request;
            int? serverPort = _contextAccessor.HttpContext?.Connection.LocalPort;
            string baseUrl = string.Empty;

            if (httpRequest is not null)
            {
                baseUrl = $"{httpRequest.Scheme}://{httpRequest.Host.Host}:{serverPort}";
            }

            return baseUrl;
        }
    }
}
