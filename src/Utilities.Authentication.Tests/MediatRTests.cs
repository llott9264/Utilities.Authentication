using Moq;
using Utilities.Authentication.Contracts;
using Utilities.Authentication.Exceptions;
using Utilities.Authentication.MediatR;

namespace Utilities.Authentication.Tests;

public class MediatRTests
{
	[Fact]
	public async Task GetUserByUserName_ReturnsExpectedStrings()
	{
		//Arrange
		Mock<IDirectoryServiceUser> mockUser = new();

		_ = mockUser.Setup(x => x.DoesUserExist()).Returns(true);
		_ = mockUser.Setup(x => x.GetUserName()).Returns("jdoe");
		_ = mockUser.Setup(x => x.GetFirstName()).Returns("John");
		_ = mockUser.Setup(x => x.GetMiddleName()).Returns("W");
		_ = mockUser.Setup(x => x.GetLastName()).Returns("Doe");
		_ = mockUser.Setup(x => x.GetDisplayName()).Returns("John Doe");
		_ = mockUser.Setup(x => x.GetEmailAddress()).Returns("jdoe@email.com");
		_ = mockUser.Setup(x => x.GetTelephoneNumber()).Returns("5551234");
		_ = mockUser.Setup(x => x.IsAccountLockedOut()).Returns(false);
		_ = mockUser.Setup(x => x.GetGroups()).Returns(
		[
			"Readers",
			"Writers",
			"Admin"
		]);

		Mock<IUserFactory> mockFactory = new();
		_ = mockFactory.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>()))
			.Returns(mockUser.Object);

		GetUserByUserNameQuery request = new("swe", "jdoe");
		GetUserByUserNameQueryHandler handler = new(mockFactory.Object);

		//Act
		IUser? result = await handler.Handle(request, CancellationToken.None);

		//Assert
		Assert.NotNull(result);
		Assert.Equal("jdoe", result.UserName);
		Assert.Equal("John", result.FirstName);
		Assert.Equal("W", result.MiddleName);
		Assert.Equal("Doe", result.LastName);
		Assert.Equal("John Doe", result.DisplayName);
		Assert.Equal("jdoe@email.com", result.EmailAddress);
		Assert.Equal("5551234", result.TelephoneNumber);
		Assert.True(!result.IsAccountLockedOut);
		Assert.True(result.IsInGroup("Writers"));
		Assert.False(result.IsInGroup("Maintainers"));
	}

	[Fact]
	public async Task GetUserByUserName_UserNotFound_ReturnsNull()
	{
		//Arrange
		Mock<IDirectoryServiceUser> mockUser = new();
		_ = mockUser.Setup(x => x.DoesUserExist()).Returns(false);

		Mock<IUserFactory> mockFactory = new();
		_ = mockFactory.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>())).Returns(mockUser.Object);

		GetUserByUserNameQuery request = new("swe", "jdoe");
		GetUserByUserNameQueryHandler handler = new(mockFactory.Object);

		//Act
		IUser? result = await handler.Handle(request, CancellationToken.None);

		//Assert
		Assert.Null(result);
	}

	[Fact]
	public async Task GetUserByUserName_DomainNotFound_ReturnsNull()
	{
		//Arrange
		Mock<IUserFactory> mockFactory = new();
		_ = mockFactory.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>()))
			.Throws(new DomainNotFoundException("bob"));


		GetUserByUserNameQuery request = new("bob", "jdoe");
		GetUserByUserNameQueryHandler handler = new(mockFactory.Object);

		//Act
		IUser? result = await handler.Handle(request, CancellationToken.None);

		//Assert
		Assert.Null(result);
	}
}
