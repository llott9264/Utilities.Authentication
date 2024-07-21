using System.DirectoryServices.AccountManagement;

namespace Utilities.Authentication.Interfaces;

public interface IUserPrincipalWrapper
{
	bool IsMemberOf(GroupPrincipal groupPrincipal);
}