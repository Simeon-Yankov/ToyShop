using System.Linq;
using System.Security.Claims;

using Microsoft.AspNetCore.Http;

using ToyShop.Common.Infrastructure.Services.Users.Contracts;

namespace ToyShop.Common.Infrastructure.Services.Users
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor) 
            => this.user = httpContextAccessor.HttpContext?.User;
        public string GetId() 
            => this.user
                ?.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;

        public string GetUserName() 
            => this.user
                ?.Identity
                ?.Name;
    }
}