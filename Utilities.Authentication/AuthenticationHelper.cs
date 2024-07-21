using System.DirectoryServices.AccountManagement;
using Utilities.Authentication.Interfaces;
using Utilities.Authentication.Wrappers;

namespace Utilities.Authentication
{
	public class AuthenticationHelper
	{
		public static bool IsUserInGroup(string domainName, string userName, string groupName)
		{
			bool isUserInGroup = false;

			IPrincipalContextWrapper principalContextWrapper = PrincipalContextWrapper.GetPrincipalContextWrapper(ContextType.Domain, domainName);
			IGroupPrincipalWrapper group = GroupPrincipalWrapper.FindByIdentity(principalContextWrapper.GetPrincipalContext(), groupName);
			IUserPrincipalWrapper user = UserPrincipalWrapper.FindByIdentity(principalContextWrapper.GetPrincipalContext(), userName.ToLower());
			isUserInGroup = user.IsMemberOf(group.GetGroupPrincipal());

			return isUserInGroup;
		}
	}
}
