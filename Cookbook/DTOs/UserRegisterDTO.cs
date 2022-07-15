using System.ComponentModel.DataAnnotations;

namespace Cookbook.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
