using Utilities.Authentication.Contracts;
using Utilities.Authentication.Exceptions;

namespace Utilities.Authentication;

internal class UserService(IActiveDirectoryFactory adFactory)
{
	public IUser? GetUser(string domain, string username)
	{
		try
		{
			IActiveDirectoryUser adUser = adFactory.CreateUser(domain, username);
			return !adUser.DoesUserExist()
				? null
				: (IUser)new User
				{
					SamAccountName = adUser.GetSamAccountName(),
					FirstName = adUser.GetFirstName(),
					MiddleName = adUser.GetMiddleName(),
					LastName = adUser.GetLastName(),
					DisplayName = adUser.GetDisplayName(),
					EmailAddress = adUser.GetEmailAddress(),
					TelephoneNumber = adUser.GetTelephoneNumber(),
					Groups = adUser.GetGroups()
				};
		}
		catch (DomainNotFoundException)
		{
			return null;
		}
	}
}