using MediatR;
using Utilities.Authentication.Contracts;

namespace Utilities.Authentication.MediatR;

public class GetUserByUserNameQueryHandler(IActiveDirectoryFactory activeDirectoryFactory)
	: IRequestHandler<GetUserByUserNameQuery, IUser?>
{
	public Task<IUser?> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
	{
		UserService userService = new(activeDirectoryFactory);
		IUser? user = userService.GetUser(request.Domain, request.UserName);
		return Task.FromResult(user);
	}
}