using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestUser.Model;

namespace TestUser.MediatR.Queries
{
    public class DeleteUserQuery : IRequest<User>
    {
        public int ID { get; }
        public DeleteUserQuery(int id)
        {
            ID = id;
        }
    }
}
