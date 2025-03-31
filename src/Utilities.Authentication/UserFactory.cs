using Utilities.Authentication.Contracts;

namespace Utilities.Authentication;

internal class UserFactory : IUserFactory
{
	public IUser Create(string domain, string username)
	{
		return new ActiveDirectoryUser(domain, username);
	}
}
