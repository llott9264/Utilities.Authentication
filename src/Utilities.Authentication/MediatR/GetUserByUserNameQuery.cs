using MediatR;
using Utilities.Authentication.Contracts;

namespace Utilities.Authentication.MediatR;

public class GetUserByUserNameQuery(string domain, string userName) : IRequest<IUserModel?>
{
	public string Domain => domain;
	public string UserName => userName;
}
