using MediatR;
using Utilities.Authentication.Contracts;
using Utilities.Authentication.Exceptions;

namespace Utilities.Authentication.MediatR;

public class GetUserByUserNameQueryHandler(IUserFactory activeDirectoryFactory)
	: IRequestHandler<GetUserByUserNameQuery, IUserModel?>
{
	public Task<IUserModel?> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
	{
		try
		{
			IUser user = activeDirectoryFactory.Create(request.Domain, request.UserName);
			return Task.FromResult(!user.DoesUserExist()
				? null
				: (IUserModel)new UserModel
				{
					SamAccountName = user.GetSamAccountName(),
					FirstName = user.GetFirstName(),
					MiddleName = user.GetMiddleName(),
					LastName = user.GetLastName(),
					DisplayName = user.GetDisplayName(),
					EmailAddress = user.GetEmailAddress(),
					TelephoneNumber = user.GetTelephoneNumber(),
					Groups = user.GetGroups()
				});
		}
		catch (DomainNotFoundException)
		{
			return Task.FromResult<IUserModel?>(null);
		}
	}
}
