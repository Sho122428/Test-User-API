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
    public class DeleteUserHandler : IRequestHandler<DeleteUserQuery,User>
    {
        private UserDBContext userDBContext;

        public DeleteUserHandler(UserDBContext context)
        {
            userDBContext = context;
        }

        public async Task<User> Handle(DeleteUserQuery request, CancellationToken cancellationToken)
        {
            var result = userDBContext.Users.Find(request.ID);

            if (result == null)
            {
                return null;
            }

            result.IsActive = false;
            result.IsDeleted = true;

            await userDBContext.SaveChangesAsync();

            return result;
        }
    }
}
