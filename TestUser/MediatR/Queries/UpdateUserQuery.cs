using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestUser.Model;

namespace TestUser.MediatR.Queries
{
    public class UpdateUserQuery : IRequest<User>
    {
        public User UpdateUser { get; set; }
        public UpdateUserQuery(User user)
        {
            UpdateUser = user;
        }
    }
}
