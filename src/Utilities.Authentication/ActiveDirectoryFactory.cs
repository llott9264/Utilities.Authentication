using Utilities.Authentication.Contracts;

namespace Utilities.Authentication;

public class ActiveDirectoryFactory : IActiveDirectoryFactory
{
	public IActiveDirectoryUser CreateUser(string domain, string username)
	{
		return new ActiveDirectoryUser(domain, username);
	}
}