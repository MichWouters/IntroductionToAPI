using MyFirstApi.DTO;
using System.Threading.Tasks;

namespace MyFirstApi.Services
{
    public interface IAccountService
    {
        Task<UserDto> RegisterAsync(string userName, string password);
        Task<bool> UserExists(string name);
        Task<UserDto> LoginAsync(string name, string password);
    }
}