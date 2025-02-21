using System.DirectoryServices.AccountManagement;

namespace Wlf.Utilities.Authentication;

public class User
{
	public User(string domain, string userName)
	{
		GetUserInformation(domain, userName);
	}

	public string SamAccountName { get; private set; } = string.Empty;
	public string FirstName { get; private set; } = string.Empty;
	public string MiddleName { get; private set; } = string.Empty;
	public string LastName { get; private set; } = string.Empty;
	public string EmailAddress { get; private set; } = string.Empty;
	public string DisplayName { get; private set; } = string.Empty;
	public string TelephoneNumber { get; private set; } = string.Empty;
	public List<Group> Groups { get; } = new();

	private void GetUserInformation(string domain, string userName)
	{
		using (PrincipalContext principalContext = new(ContextType.Domain, domain))
		{
			using (UserPrincipal? userPrincipal = UserPrincipal.FindByIdentity(principalContext, userName.ToLower()))
			{
				if (userPrincipal != null)
				{
					SamAccountName = userPrincipal.SamAccountName;
					FirstName = userPrincipal.GivenName;
					MiddleName = userPrincipal.MiddleName;
					LastName = userPrincipal.Surname;
					DisplayName = userPrincipal.DisplayName;
					EmailAddress = userPrincipal.EmailAddress;
					TelephoneNumber = userPrincipal.VoiceTelephoneNumber;

					PrincipalSearchResult<Principal>? groups = userPrincipal.GetAuthorizationGroups();

					foreach (Principal principal in groups)
					{
						Groups.Add(new Group(principalContext.Name, principal.SamAccountName));
					}
				}
			}
		}
	}
}
