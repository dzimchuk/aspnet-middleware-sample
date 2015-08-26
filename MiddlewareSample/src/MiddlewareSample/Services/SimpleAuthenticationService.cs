using System;
using System.Threading.Tasks;
using MiddlewareSample.Infrastructure;

namespace MiddlewareSample.Services
{
    internal class SimpleAuthenticationService : IAuthenticationService
    {
        public Task AuthenticateAsync(string username, string password)
        {
            if ("testuser".Equals(username, StringComparison.OrdinalIgnoreCase) &&
                "testpwd".Equals(password))
            {
                return Task.FromResult(0);
            }

            throw new InvalidCredentialsException();
        }
    }
}