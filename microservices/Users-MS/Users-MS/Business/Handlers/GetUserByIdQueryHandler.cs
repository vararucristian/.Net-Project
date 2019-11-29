using MediatR;
using Users_Ms.Business.Commands;
using Users_Ms.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Users_Ms.Business.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly UserContext UserContext;

        public GetUserByIdQueryHandler(UserContext userContext)
        {
            UserContext = userContext;
        }
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var users = UserContext.Users;
            var user = users.Where(u => u.Id == request.Id).FirstOrDefault();
            return user;
        }
    }
}
