using System.Threading.Tasks;

namespace MyFirstApi.Services
{
    public interface IAccountService
    {
        Task<AppUser> RegisterAsync(string userName, string password);
    }
}