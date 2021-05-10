using Microsoft.EntityFrameworkCore;
using MyFirstApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApi.Services
{
    public class AppUserService : IAppUserService
    {
        private AppContext _context;

        public AppUserService(AppContext context)
        {
            // Dependency Injection
            _context = context;
        }

        public async Task<List<AppUser>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddUser(AppUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<AppUser> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public Task<MemberDto> GetMemberAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}