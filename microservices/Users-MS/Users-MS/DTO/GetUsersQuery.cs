using MediatR;
using Users_Ms.Data;
using System.Collections.Generic;

namespace Users_Ms.Business.Commands
{
    public class GetUsersQuery : IRequest<List<User>>
    {

    }
}
