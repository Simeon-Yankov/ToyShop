namespace ToyShop.Services.Identity.Contracts
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string userName, string secret);
    }
}