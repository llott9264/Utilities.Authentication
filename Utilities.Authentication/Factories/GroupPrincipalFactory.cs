using System.DirectoryServices.AccountManagement;
using Utilities.Authentication.Interfaces;
using Utilities.Authentication.Wrappers;

namespace Utilities.Authentication.Factories;

public class GroupPrincipalFactory : IGroupPrincipalFactory
{
	public IGroupPrincipalWrapper Create(PrincipalContext principalContext, string groupName)
	{
		GroupPrincipal groupPrincipal = GroupPrincipal.FindByIdentity(principalContext, groupName);
		return new GroupPrincipalWrapper(groupPrincipal);
	}
}