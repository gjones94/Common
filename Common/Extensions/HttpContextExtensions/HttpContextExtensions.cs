using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions.HttpContextExtensions
{
    public static class HttpContextExtensions
    {
        public static string GetServerUrl(this HttpContext context)
        {
            HttpRequest? httpRequest = context.Request;
            int? serverPort = context?.Connection.LocalPort;

            string baseUrl = string.Empty;

            if (httpRequest is not null)
            {
                baseUrl = $"{httpRequest.Scheme}://{httpRequest.Host.Host}:{serverPort}";
            }

            return baseUrl;
        }
    }
}
