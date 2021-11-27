using System.ComponentModel.DataAnnotations;

namespace ToyShop.Server.Models.Identity
{
    public class LoginRequestModel
    {
        [Required]
        public string UserName { get; init; }


        [Required]
        public string Password { get; init; }
    }
}