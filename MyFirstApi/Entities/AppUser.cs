using MyFirstApi.Helpers;
using System;
using System.Collections.Generic;

namespace MyFirstApi
{
    public class AppUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public DateTime DateOfBirth{ get; set; }

        public string Gender { get; set; }

        public string Interests { get; set; }

        public string City { get; set; }

        public string CountryOfOrigin { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime LastModified { get; set; } = DateTime.Now;

        // One to many
        public ICollection<Photo> Photos { get; set; }
    }
}