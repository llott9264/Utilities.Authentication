using System.DirectoryServices.AccountManagement;
using Utilities.Authentication.Contracts;
using Utilities.Authentication.Exceptions;

namespace Utilities.Authentication;

public class ActiveDirectoryUser : IActiveDirectoryUser
{
	private readonly UserPrincipal? _userPrincipal;

	public ActiveDirectoryUser(string domain, string username)
	{
		try
		{
			PrincipalContext context = new(ContextType.Domain, domain);
			_userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username);
		}
		catch (PrincipalServerDownException)
		{
			throw new DomainNotFoundException(domain);
		}
	}

	public bool DoesUserExist()
	{
		return _userPrincipal != null;
	}

	public string GetSamAccountName()
	{
		return _userPrincipal?.SamAccountName ?? string.Empty;
	}

	public string GetFirstName()
	{
		return _userPrincipal?.GivenName ?? string.Empty;
	}

	public string GetMiddleName()
	{
		return _userPrincipal?.MiddleName ?? string.Empty;
	}

	public string GetLastName()
	{
		return _userPrincipal?.Surname ?? string.Empty;
	}

	public string GetDisplayName()
	{
		return _userPrincipal?.DisplayName ?? string.Empty;
	}

	public string GetEmailAddress()
	{
		return _userPrincipal?.EmailAddress ?? string.Empty;
	}

	public string GetTelephoneNumber()
	{
		return _userPrincipal?.VoiceTelephoneNumber ?? string.Empty;
	}

	public bool IsAccountLockedOut()
	{
		return _userPrincipal?.IsAccountLockedOut() ?? false;
	}

	public List<string> GetGroups()
	{
		return _userPrincipal != null
			? _userPrincipal.GetAuthorizationGroups()
				.Select(g => g.Name)
				.ToList()
			: [];
	}
}