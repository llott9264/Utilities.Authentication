using System.DirectoryServices.AccountManagement;
using Utilities.Authentication.Interfaces;

namespace Utilities.Authentication.Wrappers;

public class GroupPrincipalWrapper(GroupPrincipal groupPrincipal) : IGroupPrincipalWrapper
{
    public GroupPrincipal GetGroupPrincipal()
    {
        return groupPrincipal;
    }
}