using MediatR;
using Users_Ms.Data;

namespace Users_MS.DTO
{
    public class CreateUser: IRequest<User>
    {
        public string FirstName { get;  set; }

        public string LastName { get;  set; }

        public string UserName { get;  set; }

        public string Email { get;  set; }

        public string Password { get;  set; }

        public CreateUser(string firstName,string lastName,string userName,string email , string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Password = password;
        }

    }
}
