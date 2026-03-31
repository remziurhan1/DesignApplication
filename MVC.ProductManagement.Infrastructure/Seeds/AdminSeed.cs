
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
        private const string salesEmail = "mehmet.okur@cryocan.com";
        private const string salesPassword = "password+0";
        private const string salesPhoneNumber = "123456789";
        private const string secondSalesEmail = "sarp.yilmaz@cryocan.com";
        private const string secondSalesPhoneNumber = "987654321";
        private const string managerEmail = "mudur.satis@cryocan.com";
        private const string managerPhoneNumber = "5550000000";
        private const string designEngineerEmail = "dizayn.muhendis@cryocan.com";
        private const string designEngineerPhoneNumber = "5551112233";
        private const string designManagerEmail = "dizayn.mudur@cryocan.com";
        private const string designManagerPhoneNumber = "5551112244";
        private const string seedCustomerCompany = "Cryocan Seed Müşteri";
        private const string seedCustomerEmail = "seed.customer@cryocan.com";

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

            await AddRolesAsync(context);
            if (!context.Users.Any(user => user.Email == adminEmail))
            {
                await AddAdminAsync(context);
            }
            if (!context.Users.Any(user => user.Email == salesEmail))
            {
                await AddSalesEngineerAsync(context, salesEmail, "Mehmet Okur", salesPhoneNumber, "Europe");
            }
            if (!context.Users.Any(user => user.Email == secondSalesEmail))
            {
                await AddSalesEngineerAsync(context, secondSalesEmail, "Sarp Yılmaz", secondSalesPhoneNumber, "MiddleEast");
            }
            if (!context.Users.Any(user => user.Email == managerEmail))
            {
                await AddSalesManagerAsync(context);
            }
            await EnsureDesignEngineerAsync(context);
            await EnsureDesignManagerAsync(context);
            if (!context.Customers.Any(x => x.CompanyName == seedCustomerCompany))
            {
                await AddSeedCustomerAsync(context);
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

        private static async Task AddSalesEngineerAsync(AppDbContext context, string email, string fullName, string phoneNumber, string region)
        {
            var user = new IdentityUser
            {
                Email = email,
                EmailConfirmed = true,
                NormalizedEmail = email.ToUpperInvariant(),
                UserName = email,
                NormalizedUserName = email.ToUpperInvariant(),
                PhoneNumber = phoneNumber,
                PhoneNumberConfirmed = true
            };
            user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, salesPassword);
            await context.Users.AddAsync(user);

            var salesRoleId = context.Roles.FirstOrDefault(role => role.Name == Roles.Sales.ToString())?.Id;
            if (!string.IsNullOrWhiteSpace(salesRoleId))
            {
                await context.UserRoles.AddAsync(new IdentityUserRole<string>
                {
                    RoleId = salesRoleId,
                    UserId = user.Id
                });
            }

            await context.EmployeeProfiles.AddAsync(new EmployeeProfile
            {
                UserId = user.Id,
                FullName = fullName,
                Department = "Satış Bölümü",
                DepartmentRole = "Satış Mühendisi",
                Title = "Satış Mühendisi",
                Number = phoneNumber,
                Email = email,
                Location = region,
                CanAccessSalesArea = true,
                CanManageSalesCustomers = true,
                CanCreateSalesRequests = true,
                CanViewSalesPricing = true,
                Status = Status.Added,
                CreatedBy = "SeedData",
                CreatedDate = DateTime.UtcNow
            });

            await context.SaveChangesAsync();
        }

        private static async Task AddSeedCustomerAsync(AppDbContext context)
        {
            await context.Customers.AddAsync(new Customer
            {
                CompanyName = seedCustomerCompany,
                ContactName = "Seed Contact",
                Email = seedCustomerEmail,
                Phone = salesPhoneNumber,
                Address = "İstanbul",
                City = "İstanbul",
                Country = "Türkiye",
                Sector = "Endüstriyel Gaz",
                MainDealerCountry = "Türkiye",
                Region = "Marmara",
                IsActive = true,
                Status = Status.Added,
                CreatedBy = "SeedData",
                CreatedDate = DateTime.UtcNow
            });

            await context.SaveChangesAsync();
        }

        private static async Task AddSalesManagerAsync(AppDbContext context)
        {
            var user = new IdentityUser
            {
                Email = managerEmail,
                EmailConfirmed = true,
                NormalizedEmail = managerEmail.ToUpperInvariant(),
                UserName = managerEmail,
                NormalizedUserName = managerEmail.ToUpperInvariant(),
                PhoneNumber = managerPhoneNumber,
                PhoneNumberConfirmed = true
            };
            user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, salesPassword);
            await context.Users.AddAsync(user);

            var salesRoleId = context.Roles.FirstOrDefault(role => role.Name == Roles.Sales.ToString())?.Id;
            if (!string.IsNullOrWhiteSpace(salesRoleId))
            {
                await context.UserRoles.AddAsync(new IdentityUserRole<string>
                {
                    RoleId = salesRoleId,
                    UserId = user.Id
                });
            }

            await context.EmployeeProfiles.AddAsync(new EmployeeProfile
            {
                UserId = user.Id,
                FullName = "Satış Müdürü",
                Department = "Satış Bölümü",
                DepartmentRole = "Satış Müdürü",
                Title = "Satış Müdürü",
                Number = managerPhoneNumber,
                Email = managerEmail,
                Location = "Global",
                CanAccessSalesArea = true,
                CanManageSalesCustomers = true,
                CanCreateSalesRequests = true,
                CanViewSalesPricing = true,
                Status = Status.Added,
                CreatedBy = "SeedData",
                CreatedDate = DateTime.UtcNow
            });

            await context.SaveChangesAsync();
        }

        private static async Task EnsureDesignEngineerAsync(AppDbContext context)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == designEngineerEmail);
            if (user == null)
            {
                user = new IdentityUser
                {
                    Email = designEngineerEmail,
                    EmailConfirmed = true,
                    NormalizedEmail = designEngineerEmail.ToUpperInvariant(),
                    UserName = designEngineerEmail,
                    NormalizedUserName = designEngineerEmail.ToUpperInvariant(),
                    PhoneNumber = designEngineerPhoneNumber,
                    PhoneNumberConfirmed = true
                };
                user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, salesPassword);
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }

            var designRoleId = context.Roles.FirstOrDefault(role => role.Name == Roles.DesignEngineer.ToString())?.Id;
            if (!string.IsNullOrWhiteSpace(designRoleId) &&
                !await context.UserRoles.AnyAsync(x => x.UserId == user.Id && x.RoleId == designRoleId))
            {
                await context.UserRoles.AddAsync(new IdentityUserRole<string>
                {
                    RoleId = designRoleId,
                    UserId = user.Id
                });
            }

            if (!await context.EmployeeProfiles.AnyAsync(x => x.UserId == user.Id))
            {
                await context.EmployeeProfiles.AddAsync(new EmployeeProfile
                {
                    UserId = user.Id,
                    FullName = "Dizayn Mühendisi",
                    Department = "Dizayn Bölümü",
                    DepartmentRole = "Dizayn Mühendisi",
                    Title = "Dizayn Mühendisi",
                    Number = designEngineerPhoneNumber,
                    Email = designEngineerEmail,
                    Location = "Global",
                    CanAccessSalesArea = false,
                    CanManageSalesCustomers = false,
                    CanCreateSalesRequests = false,
                    CanViewSalesPricing = false,
                    Status = Status.Added,
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                });
            }

            await context.SaveChangesAsync();
        }

        private static async Task EnsureDesignManagerAsync(AppDbContext context)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == designManagerEmail);
            if (user == null)
            {
                user = new IdentityUser
                {
                    Email = designManagerEmail,
                    EmailConfirmed = true,
                    NormalizedEmail = designManagerEmail.ToUpperInvariant(),
                    UserName = designManagerEmail,
                    NormalizedUserName = designManagerEmail.ToUpperInvariant(),
                    PhoneNumber = designManagerPhoneNumber,
                    PhoneNumberConfirmed = true
                };
                user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, salesPassword);
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }

            var designManagerRoleId = context.Roles.FirstOrDefault(role => role.Name == Roles.DesignManager.ToString())?.Id;
            if (!string.IsNullOrWhiteSpace(designManagerRoleId) &&
                !await context.UserRoles.AnyAsync(x => x.UserId == user.Id && x.RoleId == designManagerRoleId))
            {
                await context.UserRoles.AddAsync(new IdentityUserRole<string>
                {
                    RoleId = designManagerRoleId,
                    UserId = user.Id
                });
            }

            if (!await context.EmployeeProfiles.AnyAsync(x => x.UserId == user.Id))
            {
                await context.EmployeeProfiles.AddAsync(new EmployeeProfile
                {
                    UserId = user.Id,
                    FullName = "Dizayn Müdürü",
                    Department = "Dizayn Bölümü",
                    DepartmentRole = "Dizayn Müdürü",
                    Title = "Dizayn Müdürü",
                    Number = designManagerPhoneNumber,
                    Email = designManagerEmail,
                    Location = "Global",
                    CanAccessSalesArea = false,
                    CanManageSalesCustomers = false,
                    CanCreateSalesRequests = false,
                    CanViewSalesPricing = false,
                    Status = Status.Added,
                    CreatedBy = "SeedData",
                    CreatedDate = DateTime.UtcNow
                });
            }

            await context.SaveChangesAsync();
        }

    }
}
