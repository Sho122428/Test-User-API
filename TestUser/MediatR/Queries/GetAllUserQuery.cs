using MediatR;
using System.Collections.Generic;
using TestUser.Model;

namespace TestUser.MediatR.Queries
{
    public class GetAllUserQuery : IRequest<List<NewUser>>
    {
    }
}
