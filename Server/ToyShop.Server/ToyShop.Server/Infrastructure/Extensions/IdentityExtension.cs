using System.Linq;
using System.Security.Claims;

namespace ToyShop.Server.Infrastructure.Extensions
{
    public static class IdentityExtension
    {
        public static string Id(this ClaimsPrincipal user) 
            => user
                .Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;
    }
}