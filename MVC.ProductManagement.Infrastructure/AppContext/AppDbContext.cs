using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.Configurations;
using MVC.ProductManagement.Infrastructure.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.AppContext
{
    public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Admin> Admins { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialForm> MaterialForms { get; set; }
        public DbSet<YieldStrength> YieldStrengths { get; set; }
        public DbSet<AllowableStress> AllowableStresses { get; set; }
        public DbSet<EN13458Calculation> EN13458Calculations { get; set; }
        public DbSet<StorageTypeProperties> StorageTypeProperties { get; set; }
        public DbSet<StorageType> StorageTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(IEntityConfiguration).Assembly);
            base.OnModelCreating(builder);

            // en sonda seed dataları ekle
            builder.Entity<Material>().HasData(MaterialSeed.Get());
            builder.Entity<MaterialForm>().HasData(MaterialFormSeed.Get());
            builder.Entity<YieldStrength>().HasData(YieldStrengthSeed.Get());
        }
        public override int SaveChanges()
        {
            SetBaseProperties();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetBaseProperties();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetBaseProperties()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            var userId = "UserNotFound";

            foreach (var entry in entries)
            {
                SetIfAdded(entry, userId);
                SetIfModified(entry, userId);
                SetIfDeleted(entry, userId);
            }

        }

        private void SetIfDeleted(EntityEntry<BaseEntity> entry, string userId)
        {
            if (entry.State != EntityState.Deleted)
            {
                return;
            }
            if (entry.Entity is not AuditableEntity entity)
            {
                return;
            }
            entry.State = EntityState.Modified;
            entry.Entity.Status = Status.Deleted;
            entity.DeletedDate = DateTime.Now;
            entity.DeletedBy = userId;

        }

        private void SetIfModified(EntityEntry<BaseEntity> entry, string userId)
        {
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.Status = Status.Modified;
                entry.Entity.ModifiedBy = userId;
                entry.Entity.ModifiedDate = DateTime.Now;
            }
        }

        private void SetIfAdded(EntityEntry<BaseEntity> entry, string userId)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.Status = Status.Added;
                entry.Entity.CreatedBy = userId;
                entry.Entity.CreatedDate = DateTime.Now;
            }
        }
    }
}
