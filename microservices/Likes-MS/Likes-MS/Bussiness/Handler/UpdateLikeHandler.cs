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
    public class UpdateLikeHandler: IRequestHandler<UpdateLike, Dictionary<string, object>>
    {
        private readonly LikeContext LikeContext;
        private readonly IMediator _mediator;

        public UpdateLikeHandler(LikeContext likeContext , IMediator mediator)
        {
            LikeContext = likeContext;
            _mediator = mediator;
        }

        public async Task<Dictionary<string, object>> Handle(UpdateLike request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, object>();
            var succes = true;

            var getResponse = await _mediator.Send(new GetLikeByIdsQuery(request.PersonId, request.PetId));
            var like = (Like)getResponse["like"];
            like.PetLike = request.PetLike;
            try { 
                LikeContext.SaveChanges();
            }
            catch { succes = false; }
            response.Add("succes", succes);
            response.Add("like", like);
            return response;
        }
    }
}
