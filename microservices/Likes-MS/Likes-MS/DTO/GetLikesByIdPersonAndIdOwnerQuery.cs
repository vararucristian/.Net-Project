using Likes_MS.Data;
using MediatR;
using System;
using System.Collections.Generic;

namespace Likes_MS.DTO
{
    public class GetLikesByIdPersonAndIdOwnerQuery : IRequest<List<Like>>
    {

        public Guid PersonId { get; set; }
        public Guid PetOwnerId { get; set; }

        public GetLikesByIdPersonAndIdOwnerQuery(Guid personId, Guid petOwnerId)
        {
            PersonId = personId;
            PetOwnerId = petOwnerId;
        }
    }
}
