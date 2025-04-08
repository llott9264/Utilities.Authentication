namespace Utilities.Authentication.Contracts;

public interface IUserFactory
{
	public IDirectoryServiceUser Create(string domain, string username);
}
