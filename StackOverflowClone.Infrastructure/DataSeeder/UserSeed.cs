using Microsoft.AspNetCore.Identity;
using StackOverflowClone.Infrastructure.Fearures.Membership;

namespace StackOverflowClone.Infrastructure.DataSeeder
{
    public static class UserSeed
    {
        public static IList<ApplicationUser> Users()
        {
            var passHasher = new PasswordHasher<ApplicationUser>();
            var admin = new ApplicationUser()
            {
                Id = new Guid("17FA016F-AE8B-4044-80E3-ABD54DFE392F"),
                UserName = "admin",
                FirstName="FN admin",
                LastName="LN admin",
                PhoneNumber = "1234567890",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = true,
                SecurityStamp = "BFCC7B453A8B4B6C8A4C93EE28A3B4A8"
            };
          
            admin.PasswordHash = passHasher.HashPassword(admin, "1234");
            var manager = new ApplicationUser()
            {
                Id = new Guid("8FD9FC20-5382-4F44-88FD-C78993A1D8E5"),
                UserName = "manager",
                FirstName = "FN manager",
                LastName = "LN manager",
                PhoneNumber = "1234567890",
                NormalizedUserName = "MANAGER",
                Email = "manager@gmail.com",
                NormalizedEmail = "MANAGER@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = true,
                SecurityStamp = "FC37C84E276C4D978DF9054129D0CB23",
            };
            manager.PasswordHash = passHasher.HashPassword(manager, "12345");
            var users = new List<ApplicationUser>() { admin, manager }; 
            return users;
        }
    }
}
