using System.DirectoryServices.AccountManagement;
using Utilities.Authentication.Factories;
using Utilities.Authentication.Interfaces;

namespace Utilities.Authentication
{
	public class AuthenticationHelper
	{
		public static bool IsUserInGroup(string domainName, string userName, string groupName)
		{
			IPrincipalContextFactory principalContextFactory = new PrincipalContextFactory();
			IPrincipalContextWrapper principalContextWrapper = principalContextFactory.Create(ContextType.Domain, domainName);

			IGroupPrincipalFactory groupFactory = new GroupPrincipalFactory();
			IGroupPrincipalWrapper groupPrincipalWrapper = groupFactory.Create(principalContextWrapper.GetPrincipalContext(), groupName);

			IUserPrincipalFactory userFactory = new UserPrincipalFactory();
			IUserPrincipalWrapper userPrincipalWrapper = userFactory.Create(principalContextWrapper.GetPrincipalContext(), userName.ToLower());

			return userPrincipalWrapper.IsMemberOf(groupPrincipalWrapper.GetGroupPrincipal());
		}
	}
}
