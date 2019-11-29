using MediatR;
using Users_Ms.Business.Commands;
using Users_Ms.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Users_Ms.Business.Handlers
{

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly UserContext UserContext;

        public GetUsersQueryHandler(UserContext userContext)
        {
            UserContext = userContext;
        }

        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return UserContext.Users.ToList();
        }


    }
}
