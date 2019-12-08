using MediatR;
using Messages_MS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messages_MS.DTO
{
    public class GetMessagesQuery : IRequest<List<Message>>
    {

    }
}
