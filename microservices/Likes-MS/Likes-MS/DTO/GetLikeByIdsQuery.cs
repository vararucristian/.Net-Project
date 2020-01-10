using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Likes_MS.DTO
{
    public class GetLikeByIdsQuery: IRequest<Dictionary<string, object>>
    {

        public Guid PersonId { get; set; }
        public Guid PetId { get; set; }

        public GetLikeByIdsQuery(Guid personId, Guid petId)
        {
            PersonId = personId;
            PetId = petId;
        }
    }
}
