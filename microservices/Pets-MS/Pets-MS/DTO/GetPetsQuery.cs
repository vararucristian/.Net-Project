using MediatR;
using Pets_MS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_MS.DTO
{
    public class GetPetsQuery:IRequest<List<Dictionary<string, object>>>
    {

    }
}
