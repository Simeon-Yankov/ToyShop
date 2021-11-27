namespace ToyShop.Services.Identity.Models
{
    public class RegisterUserRequestServiceModel
    {
        public string UserName { get; init; }

        public string Email { get; init; }

        public string Password { get; init; }
    }
}