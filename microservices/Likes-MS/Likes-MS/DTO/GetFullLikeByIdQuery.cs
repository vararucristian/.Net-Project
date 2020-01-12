using MediatR;
using System;
using System.Collections.Generic;

namespace Likes_MS.DTO
{
    public class GetFullLikeByIdQuery : IRequest<Dictionary<string, object>>
    {
        public Guid Id { get; set; }

        public GetFullLikeByIdQuery(Guid personId)
        {
            Id = personId;
        }
        
    }
}
