using MyFirstApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstApi.Services
{
    public interface IAppUserService
    {
        Task AddUser(AppUser user);
        Task<AppUser> GetUser(int id);
        Task<List<AppUser>> GetUsers();
        Task<MemberDto> GetMemberAsync(int id);
    }
}