using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApi.Services
{
    public class AccountService : IAccountService
    {
        private AppContext _context;

        public AccountService(AppContext context)
        {
            _context = context;
        }

        public async Task<AppUser> RegisterAsync(string userName, string password)
        {
            using var hmac = new HMACSHA512();

            // Hash user password
            var user = new AppUser
            {
                Name = userName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
