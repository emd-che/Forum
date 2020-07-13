using System.Threading.Tasks;
using Forum.Auth;

namespace Forum.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string username, string email, string password);
    }
}