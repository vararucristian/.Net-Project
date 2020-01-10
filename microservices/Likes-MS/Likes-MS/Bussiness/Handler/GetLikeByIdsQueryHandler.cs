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
    public class GetLikeByIdsQueryHandler : IRequestHandler<GetLikeByIdsQuery, Dictionary<string, object>>
    {

        private readonly LikeContext LikeContext;
        public GetLikeByIdsQueryHandler(LikeContext likeContext)
        {
            LikeContext = likeContext;
        }

        public async Task<Dictionary<string, object>> Handle(GetLikeByIdsQuery request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, object>();
            var succes = true;
            var likes = LikeContext.Likes.ToList();
            var like = likes.Where(l => l.PersonId == request.PersonId && l.PetId == request.PetId).FirstOrDefault();
            if (like == null)
            {
                succes = false;
            }
            response.Add("succes", succes);
            response.Add("like", like);
            return response;
        }
    }
}
