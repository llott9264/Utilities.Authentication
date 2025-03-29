using Moq;
using Utilities.Authentication.Contracts;

namespace Utilities.Authentication.Tests;

public class UserServiceTests
{
	[Fact]
	public void GetUser_ReturnsExpectedStrings()
	{
		// Arrange
		Mock<IActiveDirectoryUser> mockAdUser = new();

		_ = mockAdUser.Setup(x => x.DoesUserExist()).Returns(true);
		_ = mockAdUser.Setup(x => x.GetSamAccountName()).Returns("jdoe");
		_ = mockAdUser.Setup(x => x.GetFirstName()).Returns("John");
		_ = mockAdUser.Setup(x => x.GetMiddleName()).Returns("W");
		_ = mockAdUser.Setup(x => x.GetLastName()).Returns("Doe");
		_ = mockAdUser.Setup(x => x.GetDisplayName()).Returns("John Doe");
		_ = mockAdUser.Setup(x => x.GetEmailAddress()).Returns("jdoe@email.com");
		_ = mockAdUser.Setup(x => x.GetTelephoneNumber()).Returns("5551234");
		_ = mockAdUser.Setup(x => x.IsAccountLockedOut()).Returns(false);
		_ = mockAdUser.Setup(x => x.GetGroups()).Returns(
		[
			"Readers",
			"Writers",
			"Admin"
		]);

		Mock<IActiveDirectoryFactory> mockFactory = new();
		_ = mockFactory.Setup(x => x.CreateUser("swe", "jdoe"))
			.Returns(mockAdUser.Object);

		UserService userService = new(mockFactory.Object);

		// Act
		IUser? result = userService.GetUser("swe", "jdoe");

		// Assert
		Assert.NotNull(result);
		Assert.Equal("jdoe", result.SamAccountName);
		Assert.Equal("John", result.FirstName);
		Assert.Equal("W", result.MiddleName);
		Assert.Equal("Doe", result.LastName);
		Assert.Equal("John Doe", result.DisplayName);
		Assert.Equal("jdoe@email.com", result.EmailAddress);
		Assert.Equal("5551234", result.TelephoneNumber);
		Assert.True(!result.IsAccountLockedOut);
		Assert.True(result.IsInGroup("Readers"));
		Assert.False(result.IsInGroup("Maintainers"));
	}

	[Fact]
	public void GetUser_UserNotFound_ReturnsNull()
	{
		// Arrange
		Mock<IActiveDirectoryUser> mockAdUser = new();
		_ = mockAdUser.Setup(x => x.DoesUserExist()).Returns(false);

		Mock<IActiveDirectoryFactory> mockFactory = new();
		_ = mockFactory.Setup(x => x.CreateUser("swe", "jdoe")).Returns(mockAdUser.Object);

		UserService userService = new(mockFactory.Object);

		// Act
		IUser? result = userService.GetUser("swe", "jdoe");

		// Assert
		Assert.Null(result);
	}
}