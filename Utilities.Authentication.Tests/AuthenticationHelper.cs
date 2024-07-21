using System.DirectoryServices.AccountManagement;
using Moq;
using Utilities.Authentication.Interfaces;
using Utilities.Authentication.Wrappers;

namespace Utilities.Authentication.Tests;

internal class AuthenticationHelper
{
	internal static Mock<IUserPrincipalWrapper> GetUserPrincipalMock()
	{
		Mock<IUserPrincipalWrapper> userPrincipalMock = new();
		userPrincipalMock.Setup(m => m.IsMemberOf(It.IsAny<GroupPrincipal>())).Returns(true);
		return userPrincipalMock;
	}

	internal static Mock<IUserPrincipalFactory> GetUserPrincipalFactoryMock()
	{
		Mock<IUserPrincipalFactory> userFactoryMock = new();
		userFactoryMock.Setup(m => m.Create(It.IsAny<PrincipalContext>(), It.IsAny<string>()))
			.Returns(new UserPrincipalWrapper(new UserPrincipal()));

		return userFactoryMock;
	}

	internal static Mock<IGroupPrincipalWrapper> GetGroupPrincipalMock()
	{
		Mock<IGroupPrincipalWrapper> groupPrincipalMock = new();
		groupPrincipalMock.Setup(m => m.GetGroupPrincipal()).Returns(new GroupPrincipal());
		return groupPrincipalMock;
	}
	internal static Mock<IGroupPrincipalFactory> GetGroupPrincipalFactoryMock()
	{
		Mock<IGroupPrincipalFactory> groupFactoryMock = new();
		groupFactoryMock.Setup(m => m.Create(It.IsAny<PrincipalContext>(), It.IsAny<string>()))
			.Returns(new UserPrincipalWrapper(new GroupPrincipal()));

		return groupFactoryMock;
	}

	internal static Mock<IPrincipalContextWrapper> GetPrincipalContextMock()
	{
		Mock<IPrincipalContextWrapper> principalContextMock = new();
		principalContextMock.Setup(m => m.GetPrincipalContext()).Returns(new PrincipalContext());
		return principalContextMock;
	}
	internal static Mock<IPrincipalContextFactory> GetPrincipalContextFactoryMock()
	{
		Mock<IPrincipalContextFactory> groupFactoryMock = new();
		groupFactoryMock.Setup(m => m.Create(It.IsAny<ContextType>(), It.IsAny<string>()))
			.Returns(new UserPrincipalWrapper(new PrincipalContext()));

		return groupFactoryMock;
	}
}