﻿namespace Utilities.Authentication.Contracts;

public interface IUser
{
	string UserName { get; }
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
