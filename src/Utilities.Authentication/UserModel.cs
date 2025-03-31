using Utilities.Authentication.Contracts;

namespace Utilities.Authentication;

internal class UserModel : IUserModel
{
	public string SamAccountName { get; set; } = string.Empty;
	public string FirstName { get; set; } = string.Empty;
	public string MiddleName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public string EmailAddress { get; set; } = string.Empty;
	public string DisplayName { get; set; } = string.Empty;
	public string TelephoneNumber { get; set; } = string.Empty;
	public bool IsAccountLockedOut { get; set; } = false;
	public List<string> Groups { get; set; } = [];

	public bool IsInGroup(string groupName)
	{
		return Groups.Contains(groupName);
	}
}
