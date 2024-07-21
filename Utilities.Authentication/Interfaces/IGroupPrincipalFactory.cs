using System.DirectoryServices.AccountManagement;

namespace Utilities.Authentication.Interfaces;

public interface IGroupPrincipalFactory
{
	IGroupPrincipalWrapper Create(PrincipalContext principalContext, string groupName);
}