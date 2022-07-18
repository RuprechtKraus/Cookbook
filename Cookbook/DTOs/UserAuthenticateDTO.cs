using System.ComponentModel.DataAnnotations;

namespace Cookbook.DTOs
{
    public class UserAuthenticateDTO
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
