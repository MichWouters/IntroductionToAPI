using AutoMapper;
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
        private IMapper _mapper;

        public AppUserService(AppContext context, IMapper mapper)
        {
            // Dependency Injection
            _context = context;
            _mapper = mapper;
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
            return await _context.Users
                .Include(x => x.Photos)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MemberDto> GetMemberAsync(int id)
        {
            AppUser user = await this.GetUser(id);

            // Bad practice. Use Automapper instead
            //var member = new MemberDto
            //{
            //    City = user.City,
            //    Gender = user.Gender,
            //    Interests = user.Interests
            //};

            MemberDto member = _mapper.Map<MemberDto>(user);
            return member;
        }
    }
}