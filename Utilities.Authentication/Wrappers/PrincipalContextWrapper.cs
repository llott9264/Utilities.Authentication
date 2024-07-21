using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using Utilities.Authentication.Interfaces;

namespace Utilities.Authentication.Wrappers;

public class PrincipalContextWrapper(PrincipalContext principalContext) : IPrincipalContextWrapper
{
    public PrincipalContext GetPrincipalContext() => principalContext;
}