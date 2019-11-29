using MediatR;
using Users_Ms.Data;
using System;

namespace Users_Ms.Business.Commands
{
    public class GetUserByIdQuery : IRequest<User>
    {

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
