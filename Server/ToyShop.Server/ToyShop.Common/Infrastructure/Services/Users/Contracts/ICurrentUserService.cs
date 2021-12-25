namespace ToyShop.Common.Infrastructure.Services.Users.Contracts
{
    public interface ICurrentUserService
    {
        string GetUserName();

        string GetId();
    }
}