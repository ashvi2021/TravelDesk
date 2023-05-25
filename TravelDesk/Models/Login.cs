using Microsoft.Build.Framework;

namespace TravelDesk.Models
{
    public class Login
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
