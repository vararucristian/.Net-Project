using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users_Ms.Data;
using Users_MS.DTO;

namespace Users_MS.Business.Handlers
{
    public class GetUserByUsernameAndPasswordQueryHandler : IRequestHandler<GetUserByUsernameAndPasswordQuery, User>
    {
        private readonly UserContext UserContext;
        public GetUserByUsernameAndPasswordQueryHandler(UserContext userContext)
        {
            UserContext = userContext;
        }

        public async Task<User> Handle(GetUserByUsernameAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var users = UserContext.Users;
            var user = users.Where(u => u.UserName == request.UserName && u.Password == request.Password).FirstOrDefault();
            return user;
        }
    }
}
