using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestUser.Model;

namespace TestUser.MediatR.Queries
{
    public class PostUserQuery : IRequest<User>
    {
        public User NewUsers { get; }
        public PostUserQuery(User user)
        {
            NewUsers = user;
        }
    }
}
