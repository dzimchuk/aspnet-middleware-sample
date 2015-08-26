using System;
using System.Threading.Tasks;

namespace MiddlewareSample.Infrastructure
{
    public interface IAuthenticationService
    {
        Task AuthenticateAsync(string username, string password);
    }
}