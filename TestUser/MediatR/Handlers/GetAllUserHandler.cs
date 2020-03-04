using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestUser.MediatR.Queries;
using TestUser.Model;
using TestUser.TestDBContext;

namespace TestUser.MediatR.Handlers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, List<NewUser>>
    {
        private UserDBContext userDBContext;

        public GetAllUserHandler(UserDBContext context) {
            userDBContext = context;
        }

        public async Task<List<NewUser>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var userList = userDBContext.Users;
            List<NewUser> newUsers = new List<NewUser>();

            foreach(var dtl in userList)
            {
                var user =new NewUser {
                    Id = dtl.Id,
                    FirstName = dtl.FirstName,
                    LastName = dtl.LastName
                };

                newUsers.Add(user);
            }

            return newUsers;
        }
    }
}
