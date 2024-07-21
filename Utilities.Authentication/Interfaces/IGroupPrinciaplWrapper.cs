using System.DirectoryServices.AccountManagement;

namespace Utilities.Authentication.Interfaces;

public interface IGroupPrincipalWrapper
{
	GroupPrincipal GetGroupPrincipal();
	static abstract IGroupPrincipalWrapper FindByIdentity(PrincipalContext principal, string groupName);
}