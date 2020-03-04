using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestUser.MediatR.Queries;
using TestUser.Model;
using TestUser.TestDBContext;

namespace TestUser.MediatR.Handlers
{
    public class GetUserDetailHandler : IRequestHandler<GetUserDetailQuery,User>
    {
        private UserDBContext userDBContext;

        public GetUserDetailHandler(UserDBContext context)
        {
            userDBContext = context;
        }

        public async Task<User> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var result = userDBContext.Users.Find(request.ID);

            if (result == null)
            {
                return null;
            }

            return result;
        }
    }
}
