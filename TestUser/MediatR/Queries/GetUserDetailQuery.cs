using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestUser.Model;

namespace TestUser.MediatR.Queries
{
    public class GetUserDetailQuery : IRequest<User>
    {
        public int ID { get; }
        public GetUserDetailQuery(int id) {
            ID = id;
        }       

    }
}
