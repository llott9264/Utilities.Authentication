namespace Utilities.Authentication.Contracts;

public interface IDirectoryServiceUser
{
	bool DoesUserExist();
	string GetUserName();
	string GetFirstName();
	string GetLastName();
	string GetMiddleName();
	string GetDisplayName();
	string GetEmailAddress();
	string GetTelephoneNumber();
	bool IsAccountLockedOut();
	List<string> GetGroups();
}
