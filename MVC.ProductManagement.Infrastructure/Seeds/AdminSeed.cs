
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds
{
    public static class AdminSeed
    {
        private const string adminEmail = "admin@admin.com";
        private const string adminPassword = "password+0";

        public static async Task AdminSeedAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<AppDbContext>();
            dbContextBuilder.UseSqlServer(configuration.GetConnectionString("AppConnectionString"));
            AppDbContext context = new AppDbContext(dbContextBuilder.Options);

            await context.Database.ExecuteSqlRawAsync(@"
IF OBJECT_ID('EmployeeProfiles', 'U') IS NULL
BEGIN
    CREATE TABLE [EmployeeProfiles](
        [Id] uniqueidentifier NOT NULL PRIMARY KEY,
        [UserId] nvarchar(450) NOT NULL,
        [FullName] nvarchar(150) NOT NULL,
        [Department] nvarchar(100) NOT NULL,
        [DepartmentRole] nvarchar(100) NOT NULL,
        [Title] nvarchar(50) NOT NULL,
        [Number] nvarchar(25) NOT NULL,
        [Email] nvarchar(256) NOT NULL,
        [Location] nvarchar(100) NOT NULL,
        [CanAccessSalesArea] bit NOT NULL,
        [CanManageSalesCustomers] bit NOT NULL,
        [CanCreateSalesRequests] bit NOT NULL,
        [CanViewSalesPricing] bit NOT NULL,
        [Status] int NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [DeletedDate] datetime2 NULL,
        [DeletedBy] nvarchar(max) NULL
    );
    CREATE UNIQUE INDEX [IX_EmployeeProfiles_UserId] ON [EmployeeProfiles]([UserId]);
END");

            if (!context.Roles.Any())
            {
                await AddRolesAsync(context);
            }
            if (!context.Users.Any(user => user.Email == adminEmail))
            {
                await AddAdminAsync(context);
            }


        }

        private static async Task AddAdminAsync(AppDbContext context)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = adminEmail,
                EmailConfirmed = true,
                NormalizedEmail = adminEmail.ToUpperInvariant(),
                UserName = adminEmail,
                NormalizedUserName = adminEmail.ToUpperInvariant()
            };
            user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, adminPassword);
            await context.Users.AddAsync(user);

            var adminRoleId = context.Roles.FirstOrDefault(role => role.Name == Roles.Admin.ToString()).Id;

            IdentityUserRole<string> userRole = new IdentityUserRole<string>()
            {
                RoleId = adminRoleId,
                UserId = user.Id
            };
            await context.UserRoles.AddAsync(userRole);

            await context.Admins.AddAsync(new Admin()
            {
                FirstName = "admin",
                LastName = "admin",
                Email = adminEmail,
                IdentityId = user.Id
            });
            await context.SaveChangesAsync();
        }

        private static async Task AddRolesAsync(AppDbContext context)
        {
            string[] roles = Enum.GetNames(typeof(Roles));

            for (int i = 0; i < roles.Length; i++)
            {
                if (await context.Roles.AnyAsync(role => role.Name == roles[i]))
                {
                    continue;
                }
                IdentityRole role = new IdentityRole()
                {
                    Name = roles[i],
                    NormalizedName = roles[i].ToUpperInvariant()
                };
                await context.Roles.AddAsync(role);
                await context.SaveChangesAsync();



            }

        }
    }
}
