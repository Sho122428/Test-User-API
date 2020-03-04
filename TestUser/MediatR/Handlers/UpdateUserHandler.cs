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
    public class UpdateUserHandler : IRequestHandler<UpdateUserQuery,User>
    {
        private UserDBContext userDBContext;

        public UpdateUserHandler(UserDBContext context)
        {
            userDBContext = context;
        }

        public async Task<User> Handle(UpdateUserQuery request, CancellationToken cancellationToken)
        {
            var result = userDBContext.Users.Find(request.UpdateUser.Id);

            if (result == null)
            {
                return null;
            }
            else
            {
                //result.Id = request.UpdateUser.Id;
                result.FirstName = request.UpdateUser.FirstName;
                result.LastName = request.UpdateUser.LastName;
                result.DateOfBirth = request.UpdateUser.DateOfBirth;
                //result.IsActive = request.UpdateUser.IsActive;
                //result.IsDeleted = request.UpdateUser.IsDeleted;
                
            }

            await userDBContext.SaveChangesAsync();

            return result;
        }
    }
}
