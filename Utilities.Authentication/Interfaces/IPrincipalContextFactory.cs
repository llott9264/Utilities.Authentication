using System.DirectoryServices.AccountManagement;

namespace Utilities.Authentication.Interfaces;

public interface IPrincipalContextFactory
{
	IPrincipalContextWrapper Create(ContextType domain, string domainName);
}