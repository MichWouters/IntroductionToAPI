using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstApi.Repositories
{
    public interface IAppUserRepository
    {
        Task AddUser(AppUser user);
        Task<AppUser> GetUser(int id);
        Task<List<AppUser>> GetUsers();
    }
}