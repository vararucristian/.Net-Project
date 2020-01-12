using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Likes_MS.DTO
{
    public class UpdateLike : IRequest<Dictionary<string, object>>
    {
        public Guid PersonId { get; set; }
        public Guid PetOwnerId { get; set; }

        
        public int PetLike { get; set; }
    }
}


