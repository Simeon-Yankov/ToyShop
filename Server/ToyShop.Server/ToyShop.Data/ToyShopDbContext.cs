using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using ToyShop.Common.Infrastructure.Services.Users.Contracts;
using ToyShop.Models;
using ToyShop.Models.Base.Contracts;

namespace ToyShop.Data
{
    public class ToyShopDbContext : IdentityDbContext<User>
    {
        private readonly ICurrentUserService currentUser;

        public ToyShopDbContext(ICurrentUserService currentUser)
            => this.currentUser = currentUser;

        public ToyShopDbContext(DbContextOptions<ToyShopDbContext> options, ICurrentUserService currentUser)
            : base(options)
            => this.currentUser = currentUser;

        public DbSet<Toy> Toys { get; init; }

        public DbSet<ImageUrl> ImagesUrls { get; init; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInformation();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInformation();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Toy>()
                .HasQueryFilter(t => !t.IsDeleted)
                .HasOne(t => t.User)
                .WithMany(t => t.Toys)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        private void ApplyAuditInformation()
            => this.ChangeTracker
                .Entries()
                .Where(e => e.Entity is IEntity)
                .ToList()
                .ForEach(entry =>
                {
                    var userName = currentUser.GetUserName();

                    if (entry.Entity is IDeletableEntity deletableEntity)
                    {
                        if (entry.State == EntityState.Deleted)
                        {
                            deletableEntity.DeletedOn = DateTime.UtcNow;
                            deletableEntity.DeletedBy = userName;
                            deletableEntity.IsDeleted = true;

                            entry.State = EntityState.Modified;

                            return;
                        }
                    }

                    if (entry.Entity is IEntity entity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedOn = DateTime.UtcNow;
                            entity.CreatedBy = userName;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            entity.ModifiedOn = DateTime.UtcNow;
                            entity.ModifiedBy = userName;
                        }
                    }

                });
    }
}