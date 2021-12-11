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

        public DbSet<Toy> Toys { get; init; }

        public DbSet<ImageUrl> ImagesUrls { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Toy>()
                .HasOne(t => t.User)
                .WithMany(t => t.Toys)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}