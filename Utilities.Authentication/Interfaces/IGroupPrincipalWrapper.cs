using System.DirectoryServices.AccountManagement;

namespace Utilities.Authentication.Interfaces;

public interface IGroupPrincipalWrapper
{
	GroupPrincipal GetGroupPrincipal();
}