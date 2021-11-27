using System.ComponentModel.DataAnnotations;

namespace ToyShop.Server.Models.Identity
{
    public class RegisterRequestModel
    {
        [Required]
        public string UserName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }
    }
}