using StackOverflowClone.Infrastructure.Fearures.Membership;

namespace StackOverflowClone.Infrastructure.DataSeeder
{
    public static class UserClaimSeed
    {
        public static IList<ApplicationUserClaim> Claims()
        {
           
            var claims = new List<ApplicationUserClaim>()
            {
                new ApplicationUserClaim()
                {
                    Id = 1,
                    UserId = new Guid("17FA016F-AE8B-4044-80E3-ABD54DFE392F"),
                    ClaimType = "AdminAccess", 
                    ClaimValue = "Administrator"

                },
                new ApplicationUserClaim()
                {
                    Id = 2,
                    UserId = new Guid("8FD9FC20-5382-4F44-88FD-C78993A1D8E5"),
                    ClaimType = "ManagerAccess",
                    ClaimValue = "Manager"
                },           
            };

            return claims;
        }
    }
}
