using Microsoft.AspNetCore.Identity;

namespace StackOverflowClone.Infrastructure.Fearures.Membership
{
    public class ApplicationRole : IdentityRole<Guid>
	{
		public ApplicationRole()
			: base()
		{
		}
		
		public ApplicationRole(string roleName)
			: base(roleName)
		{
		}
	}
}
