using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Users_Ms.Data;
using Users_MS.DTO;

namespace Users_MS.Business.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUser, User>
    {
        private readonly UserContext UserContext;

        public CreateUserHandler(UserContext userContext)
        {
            UserContext = userContext;
            
        }

        public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = User.Create(request.FirstName, request.LastName, request.UserName, request.Email, request.Password);
            UserContext.Users.Add(user);
            await UserContext.SaveChangesAsync(cancellationToken);
            return user;
        }
    }
}
