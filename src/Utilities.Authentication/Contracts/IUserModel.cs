namespace Utilities.Authentication.Contracts;

public interface IUserModel
{
	string SamAccountName { get; }
	string FirstName { get; }
	string MiddleName { get; }
	string LastName { get; }
	string EmailAddress { get; }
	string DisplayName { get; }
	string TelephoneNumber { get; }
	bool IsAccountLockedOut { get; }
	List<string> Groups { get; }
	bool IsInGroup(string groupName);
}
