using MediatR;
using System;
using System.Collections.Generic;

namespace Likes_MS.DTO
{
    public class CreateLike:IRequest<Dictionary<string,object>>
    {
        public Guid PersonId { get; set; }
        public Guid PetId { get; set; }
        public string PersonEMail { get; set; }

        public string Username { get; set; }
    }
}
