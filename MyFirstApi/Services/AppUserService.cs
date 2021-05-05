using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApi.Services
{
    public class AppUserService
    {
        private List<AppUser> _users = new List<AppUser>
        {
            new AppUser{ Id = 1, Name = "Michiel" },
            new AppUser{ Id = 2, Name = "Kenny" },
            new AppUser{ Id = 3, Name = "Stan" },
            new AppUser{ Id = 4, Name = "Kyle" },
            new AppUser{ Id = 5, Name = "Eric" },
        };

        public List<AppUser> GetUsers()
        {
            return _users;
        }

        public void AddUser(AppUser user)
        {
            _users.Add(user);
        }

        public AppUser GetUser(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}
