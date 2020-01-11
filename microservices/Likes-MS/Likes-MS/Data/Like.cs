using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Likes_MS.Data
{
    public class Like
    {
        public Guid Id { get; private set; }
        public Guid PersonId { get; private set; }

        public Guid PetId { get; private set; }

        public int PersonLike { get; set; }

        public int PetLike { get; set; }

        private Like(){}

        public static Like Create(Guid personId , Guid petId , int personLike , int petlike)
        {
            return new Like()
            {
                Id = Guid.NewGuid(),
                PersonId = personId,
                PetId = petId,
                PersonLike = personLike,
                PetLike = petlike
            };
        }
    }
}
