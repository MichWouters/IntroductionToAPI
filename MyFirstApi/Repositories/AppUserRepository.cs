﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstApi.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private AppContext _context;

        public AppUserRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<List<AppUser>> GetUsers()
        {
            return await _context.Users
                .Include(x => x.Photos)
                .ToListAsync();
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
    }
}