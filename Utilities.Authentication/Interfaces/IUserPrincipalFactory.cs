using System.DirectoryServices.AccountManagement;

namespace Utilities.Authentication.Interfaces;

public interface IUserPrincipalFactory
{
	IUserPrincipalWrapper Create(PrincipalContext principalContext, string userName);
}