namespace Utilities.Authentication.Contracts;

public interface IActiveDirectoryUser
{
	bool DoesUserExist();
	string GetSamAccountName();
	string GetFirstName();
	string GetLastName();
	string GetMiddleName();
	string GetDisplayName();
	string GetEmailAddress();
	string GetTelephoneNumber();
	bool IsAccountLockedOut();
	List<string> GetGroups();
}