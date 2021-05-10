using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApi.DTO
{
    public class MemberDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Interests { get; set; }

        public string City { get; set; }

        public string ProfilePicture { get; set; }
    }
}
