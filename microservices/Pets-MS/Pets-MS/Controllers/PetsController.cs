using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pets_MS.DTO;

namespace Pets_MS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PetsController(IMediator mediator)
        {

            _mediator = mediator;

        }

        [HttpGet]
        public async Task<ActionResult<string>> GetAllPetsAsync()
        {
            var response = await _mediator.Send(new GetPetsQuery());
            var json = JsonSerializer.Serialize(response);
            return json;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody]CreatePet jsonRequest)
        {

            var response = await _mediator.Send(jsonRequest);
            var json = JsonSerializer.Serialize(response);
            if (response["succes"].Equals(false))
            {
                return BadRequest(json);
            }
            else
            {
                return json;
            }
        }
    }
}
