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
    public class GetFullLikeByIdQueryHandler : IRequestHandler<GetFullLikeByIdQuery, Dictionary<string, object>>
    {

        private readonly LikeContext LikeContext;
        public GetFullLikeByIdQueryHandler(LikeContext likeContext)
        {
            LikeContext = likeContext;
        }

        public async Task<Dictionary<string, object>> Handle(GetFullLikeByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, object>();
            var succes = true;
            var likes = LikeContext.Likes.ToList();
            var filtredLikes = likes.Where(l => (l.PersonId == request.Id || l.PetOwnerId == request.Id) && l.PersonLike == 1 && l.PetLike==1);
            response.Add("succes", succes);
            response.Add("likes", filtredLikes.ToList());
            return response;
        }
    }
}
