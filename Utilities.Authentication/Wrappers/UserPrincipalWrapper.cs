using System.DirectoryServices.AccountManagement;
using Utilities.Authentication.Interfaces;

namespace Utilities.Authentication.Wrappers;

public class UserPrincipalWrapper(UserPrincipal? userPrincipal) : IUserPrincipalWrapper
{
	public bool IsMemberOf(GroupPrincipal groupPrincipal)
	{
		return userPrincipal != null && userPrincipal.IsMemberOf(groupPrincipal);
	}
}