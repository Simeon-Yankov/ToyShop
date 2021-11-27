using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using ToyShop.Models;

namespace ToyShop.Data
{
    public class ToyShopDbContext : IdentityDbContext<User>
    {
        public ToyShopDbContext()
        {
        }

        public ToyShopDbContext(DbContextOptions<ToyShopDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}