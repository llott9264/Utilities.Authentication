using Microsoft.Extensions.DependencyInjection;
using Utilities.Authentication.Contracts;

namespace Utilities.Authentication;

public static class AuthenticationServiceRegistration
{
	public static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
	{
		_ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
		_ = services.AddScoped<IActiveDirectoryFactory, ActiveDirectoryFactory>();
		return services;
	}
}