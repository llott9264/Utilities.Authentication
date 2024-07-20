using System.DirectoryServices.AccountManagement;

namespace Utilities.Authentication
{
	public class AuthenticationHelper
	{
		public static bool IsUserInGroup(string domainName, string userName, string groupName)
		{
			bool isUserInGroup = false;

			using (PrincipalContext principalContext = new(ContextType.Domain, domainName))
			{
				using (GroupPrincipal groupPrincipal = GroupPrincipal.FindByIdentity(principalContext, groupName))
				{
					using (UserPrincipal? userPrincipal = UserPrincipal.FindByIdentity(principalContext, userName.ToLower()))
					{
						isUserInGroup = userPrincipal != null && userPrincipal.IsMemberOf(groupPrincipal);
					}
				}
			}

			return isUserInGroup;
		}
	}
}
