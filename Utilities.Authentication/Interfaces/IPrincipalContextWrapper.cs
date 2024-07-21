using System.DirectoryServices.AccountManagement;

namespace Utilities.Authentication.Interfaces;

public interface IPrincipalContextWrapper
{
	PrincipalContext GetPrincipalContext();
}