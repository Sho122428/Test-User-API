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
    public class PostUserHandler : IRequestHandler<PostUserQuery,User>
    {
        private UserDBContext userDBContext;

        public PostUserHandler(UserDBContext context)
        {
            userDBContext = context;
        }

        public async Task<User> Handle(PostUserQuery request, CancellationToken cancellationToken)
        {
            User newRequest;

            if (request == null)
            {
                return null;
            }
            else {
                userDBContext.Add(newRequest = new User {
                    Id = request.NewUsers.Id,
                    FirstName = request.NewUsers.FirstName,
                    LastName = request.NewUsers.LastName,
                    DateOfBirth = request.NewUsers.DateOfBirth,
                    IsActive = true,
                    IsDeleted = false
                });
            }

            userDBContext.SaveChanges();

            return newRequest;
        }
    }
}
