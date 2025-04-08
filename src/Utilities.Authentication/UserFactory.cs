using Utilities.Authentication.Contracts;

namespace Utilities.Authentication;

internal class UserFactory : IUserFactory
{
	public IDirectoryServiceUser Create(string domain, string username)
	{
		return new ActiveDirectoryUser(domain, username);
	}
}
