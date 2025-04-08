using MediatR;
using Utilities.Authentication.Contracts;
using Utilities.Authentication.Exceptions;

namespace Utilities.Authentication.MediatR;

public class GetUserByUserNameQueryHandler(IUserFactory userFactory)
	: IRequestHandler<GetUserByUserNameQuery, IUser?>
{
	public Task<IUser?> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
	{
		try
		{
			IDirectoryServiceUser user = userFactory.Create(request.Domain, request.UserName);

			return Task.FromResult(!user.DoesUserExist()
				? null
				: (IUser)new User
				{
					UserName = user.GetUserName(),
					FirstName = user.GetFirstName(),
					MiddleName = user.GetMiddleName(),
					LastName = user.GetLastName(),
					DisplayName = user.GetDisplayName(),
					EmailAddress = user.GetEmailAddress(),
					TelephoneNumber = user.GetTelephoneNumber(),
					Groups = user.GetGroups(),
					IsAccountLockedOut = user.IsAccountLockedOut()
				});
		}
		catch (DomainNotFoundException)
		{
			return Task.FromResult<IUser?>(null);
		}
	}
}
