namespace Utilities.Authentication.Contracts;

public interface IActiveDirectoryFactory
{
	IActiveDirectoryUser CreateUser(string domain, string username);
}