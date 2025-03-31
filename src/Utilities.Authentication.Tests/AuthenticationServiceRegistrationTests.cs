using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Utilities.Authentication.Contracts;
using Utilities.Authentication.MediatR;

namespace Utilities.Authentication.Tests;

public class AuthenticationServiceRegistrationTests
{
	[Fact]
	public void AddAuthenticationServices_RegistersAllServices_CorrectlyResolvesTypes()
	{
		// Arrange
		ServiceCollection services = new();

		// Act
		_ = services.AddAuthenticationServices();
		ServiceProvider serviceProvider = services.BuildServiceProvider();

		IMediator? mediator = serviceProvider.GetService<IMediator>();
		IUserFactory? userFactory = serviceProvider.GetService<IUserFactory>();

		// Assert
		Assert.NotNull(mediator);
		_ = Assert.IsType<Mediator>(mediator);

		Assert.NotNull(userFactory);
		_ = Assert.IsType<UserFactory>(userFactory);
	}

	[Fact]
	public void AddAuthenticationServices_ReturnsServiceCollection()
	{
		// Arrange
		ServiceCollection services = new();

		// Act
		IServiceCollection result = services.AddAuthenticationServices();

		// Assert
		Assert.Same(services, result); // Ensures the method returns the same IServiceCollection
	}

	[Fact]
	public void AddAuthenticationServices_ScopedLifetime_VerifyInstanceWithinScope()
	{
		// Arrange
		ServiceCollection services = new();

		// Act
		_ = services.AddAuthenticationServices();
		ServiceProvider serviceProvider = services.BuildServiceProvider();

		// Assert
		using IServiceScope scope = serviceProvider.CreateScope();
		IMediator? service1 = scope.ServiceProvider.GetService<IMediator>();
		IMediator? service2 = scope.ServiceProvider.GetService<IMediator>();

		IUserFactory? service3 = scope.ServiceProvider.GetService<IUserFactory?>();
		IUserFactory? service4 = scope.ServiceProvider.GetService<IUserFactory?>();

		Assert.NotSame(service1, service2);
		Assert.Same(service3, service4);
	}

	[Fact]
	public void AddAuthenticationServices_ScopedLifetime_VerifyInstancesAcrossScopes()
	{
		// Arrange
		ServiceCollection services = new();

		// Act
		_ = services.AddAuthenticationServices();
		ServiceProvider serviceProvider = services.BuildServiceProvider();

		// Assert
		IMediator? service1, service2;
		IUserFactory? service3, service4;

		using (IServiceScope scope1 = serviceProvider.CreateScope())
		{
			service1 = scope1.ServiceProvider.GetService<IMediator>();
		}

		using (IServiceScope scope2 = serviceProvider.CreateScope())
		{
			service2 = scope2.ServiceProvider.GetService<IMediator>();
		}

		using (IServiceScope scope1 = serviceProvider.CreateScope())
		{
			service3 = scope1.ServiceProvider.GetService<IUserFactory>();
		}

		using (IServiceScope scope2 = serviceProvider.CreateScope())
		{
			service4 = scope2.ServiceProvider.GetService<IUserFactory>();
		}

		Assert.NotSame(service1, service2);
		Assert.NotSame(service3, service4);
	}

	[Fact]
	public void AddAuthenticationServices_GetUserByUsernameQueryHandler_VerifyMediatorHandlerExists()
	{
		// Arrange
		ServiceCollection services = new();

		// Act
		_ = services.AddAuthenticationServices();
		List<ServiceDescriptor> serviceDescriptors = services.ToList();

		// Assert
		ServiceDescriptor? handlerDescriptor = serviceDescriptors.FirstOrDefault(sd =>
			sd.ServiceType == typeof(IRequestHandler<GetUserByUserNameQuery, IUserModel?>));

		Assert.NotNull(handlerDescriptor);
		Assert.Equal(ServiceLifetime.Transient, handlerDescriptor.Lifetime);
	}
}
