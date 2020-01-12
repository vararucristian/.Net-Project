using Likes_MS.Data;
using Likes_MS.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Likes_MS.Bussiness.Handler
{
    public class GetLikesByIdPersonAndIdOwnerQueryHandler : IRequestHandler<GetLikesByIdPersonAndIdOwnerQuery, List<Like>>
    {

        private readonly LikeContext LikeContext;
        public GetLikesByIdPersonAndIdOwnerQueryHandler(LikeContext likeContext)
        {
            LikeContext = likeContext;
        }

        public async Task<List<Like>> Handle(GetLikesByIdPersonAndIdOwnerQuery request, CancellationToken cancellationToken)
        {
            var likes = LikeContext.Likes.ToList();
            var filtredLike = likes.Where(l => l.PersonId == request.PersonId && l.PetOwnerId == request.PetOwnerId);
            return filtredLike.ToList();
        }
    }
}
