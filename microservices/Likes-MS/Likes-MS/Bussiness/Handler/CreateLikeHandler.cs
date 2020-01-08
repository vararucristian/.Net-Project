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
    public class CreateLikeHandler : IRequestHandler<CreateLike, Dictionary<string, object>>
    {
        private readonly LikeContext LikeContext;

        public CreateLikeHandler(LikeContext likeContext)
        {
            LikeContext = likeContext;
        }
        public async Task<Dictionary<string, object>> Handle(CreateLike request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, object>();
            var succes = true;
            var like = Like.Create(request.PersonId, request.PetId);
            try { 
                
                LikeContext.Likes.Add(like);
                await LikeContext.SaveChangesAsync(cancellationToken);
            }
            catch (InvalidOperationException)
            {
                succes = false;
            }

            response.Add("succes", succes);
            response.Add("like", like);
            return response;

        }
    }
}
