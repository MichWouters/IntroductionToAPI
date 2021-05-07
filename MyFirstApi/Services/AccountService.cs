using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<AppUser> LoginAsync(string name, string password)
        {
            // Single throws exception if more than 1 object is found.
            AppUser user = await _context.Users
                .SingleOrDefaultAsync(x => x.Name == name);

            // Throw error if no user was found
            if (user == null)
            {
                // Bad practice: Flat out tells a hacker that this name does / does not exist
                throw new UnauthorizedAccessException("Invalid username");
            }

            // if user was found, compare password hashes to verify correct password
            // Hash password again with users personal salt to get same hash result.
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < hash.Length; i++)
            {
                // Collections cannot be compared directly. We need to check their values.
                if (hash[i] != user.PasswordHash[i])
                {
                    // Bad practice: Flat out tells a hacker that this name does / does not exist
                    throw new UnauthorizedAccessException("Invalid password");
                }
            }

            return user;
        }

        public async Task<AppUser> RegisterAsync(string userName, string password)
        {
            using var hmac = new HMACSHA512();

            // Hash user password
            var user = new AppUser
            {
                Name = userName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _context.Users.AnyAsync(x => x.Name == userName.ToLower());
        }
    }
}