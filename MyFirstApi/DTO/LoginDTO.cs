using System.ComponentModel.DataAnnotations;

namespace MyFirstApi.DTO
{
    public class LoginDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}