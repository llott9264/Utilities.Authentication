namespace Utilities.Authentication.Contracts;

public interface IUserFactory
{
	public IUser Create(string domain, string username);
}
