using MediatR;
using Users_Ms.Data;

namespace Users_MS.DTO
{
    public class GetUserByUsernameAndPasswordQuery : IRequest<User>
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public GetUserByUsernameAndPasswordQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }


    }

}
