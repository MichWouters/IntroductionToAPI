using AutoMapper;
using MyFirstApi.DTO;
using MyFirstApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstApi.Services
{
    public class AppUserService : IAppUserService
    {
        private IAppUserRepository _repo;
        private IMapper _mapper;

        public AppUserService(IAppUserRepository repo, IMapper mapper)
        {
            // Dependency Injection
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<List<AppUser>> GetUsers()
        {
            return await _repo.GetUsers();
        }

        public async Task AddUser(AppUser user)
        {
            await _repo.AddUser(user);
        }

        public async Task<AppUser> GetUser(int id)
        {
            return await _repo.GetUser(id);
        }

        
        public async Task<MemberDto> GetMemberAsync(int id)
        {
            // Bad practice. Use Automapper instead
            //var member = new MemberDto
            //{
            //    City = user.City,
            //    Gender = user.Gender,
            //    Interests = user.Interests
            //};
            AppUser user = await _repo.GetUser(id);
            MemberDto member = _mapper.Map<MemberDto>(user);
            return member;
        }
    }
}