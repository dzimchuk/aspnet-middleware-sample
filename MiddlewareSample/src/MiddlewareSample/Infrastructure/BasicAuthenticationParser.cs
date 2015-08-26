using System;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Http;

namespace MiddlewareSample.Infrastructure
{
    internal class BasicAuthenticationParser
    {
        private readonly string credentials;

        public BasicAuthenticationParser(HttpContext context)
        {
            credentials = GetCredentials(context);
        }

        public string GetUsername()
        {
            return GetValue(credentials, 0);
        }

        public string GetPassword()
        {
            return GetValue(credentials, 1);
        }

        private static string GetValue(string credentials, int index)
        {
            if (string.IsNullOrWhiteSpace(credentials))
                return null;

            var parts = credentials.Split(':');
            return parts.Length == 2 ? parts[index] : null;
        }

        private static string GetCredentials(HttpContext context)
        {
            try
            {
                string[] authHeader;
                if (context.Request.Headers.TryGetValue("Authorization", out authHeader) &&
                    authHeader.Any() &&
                    authHeader[0].StartsWith("Basic "))
                {
                    var value = Convert.FromBase64String(authHeader[0].Split(' ')[1]);
                    return Encoding.UTF8.GetString(value);
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}