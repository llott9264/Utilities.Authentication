using System.DirectoryServices.AccountManagement;
using Utilities.Authentication.Interfaces;
using Utilities.Authentication.Wrappers;

namespace Utilities.Authentication.Factories;

public class UserPrincipalFactory : IUserPrincipalFactory
{
	public IUserPrincipalWrapper Create(PrincipalContext principalContext, string userName)
	{
		UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(principalContext, userName);
		return new UserPrincipalWrapper(userPrincipal);
	}
}