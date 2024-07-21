using System.DirectoryServices.AccountManagement;
using Utilities.Authentication.Interfaces;
using Utilities.Authentication.Wrappers;

namespace Utilities.Authentication.Factories;

public class PrincipalContextFactory : IPrincipalContextFactory
{
	public IPrincipalContextWrapper Create(ContextType domain, string domainName)
	{
		PrincipalContext principalContext = new(domain, domainName);
		return new PrincipalContextWrapper(principalContext);
	}
}