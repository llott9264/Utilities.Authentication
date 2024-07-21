using System.DirectoryServices.AccountManagement;
using Moq;
using Utilities.Authentication.Interfaces;
using Utilities.Authentication.Wrappers;

namespace Utilities.Authentication.Tests;

internal class AuthenticationHelper
{
	internal static Mock<UserPrincipal> GetUserPrincipalMock()
	{
		Mock<IUserPrincipalWrapper> userPrincipalMock = new();
		userPrincipalMock.Setup(m => m.IsMemberOf(It.IsAny<GroupPrincipal>())).Returns(true);

		userPrincipalMock.Setup(m => m.IsMemberOf(It.IsAny<GroupPrincipal>())).Returns(true);
		userPrincipalMock.Setup(m => m.FindByIdentity(It.IsAny<PrincipalContext, string>, It.IsAny<string>())).Returns(new GroupPrincipalWrapper());

		
	}
}