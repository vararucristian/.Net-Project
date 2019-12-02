using MediatR;
using System;
using System.Collections.Generic;
using Users_Ms.Data;

namespace Users_MS.DTO
{
    public class DeleteUser:IRequest<User>
    {
        public DeleteUser(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
