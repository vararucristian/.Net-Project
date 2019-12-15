using System;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pets_Ms.Business.Commands;
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
            if (response.Count==0)
            {
                return NotFound(json);
            }
            else
            {
                return Ok(json);
            }
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
                return Ok(json);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetPetsByIdAsync(Guid id)
        {
            var response = await _mediator.Send(new GetPetByIdQuery(id));
            var json = JsonSerializer.Serialize(response);
            if (response["succes"].Equals(false))
            {
                return NotFound(json);
            }
            return json;
        }

        [HttpGet("username/{username}")]
        public async Task<ActionResult<string>> GetPetsByUsernameAsync(String username)
        {
            var response = await _mediator.Send(new GetPetsByUsernameQuery(username));
            var json = JsonSerializer.Serialize(response);
            if (response.Count == 0)
            {
                return NotFound(json);
            }
            else
            {
                return Ok(json);
            }
        }

        [HttpGet("species/{species}")]
        public async Task<ActionResult<string>> GetPetsBySpeciesAsync(Animal species)
        {
            var response = await _mediator.Send(new GetPetsBySpeciesQuery(species));
            var json = JsonSerializer.Serialize(response);
            if (response.Count == 0)
            {
                return NotFound(json);
            }
            else
            {
                return Ok(json);
            }
        }

        [HttpGet("{latitude}/{longitude}")]
        public async Task<ActionResult<string>> GetPetsByLocationAsync(double latitude, double longitude)
        {
            var response = await _mediator.Send(new GetPetsByLocationQuery(latitude, longitude));
            var json = JsonSerializer.Serialize(response);
            if (response.Count == 0)
            {
                return NotFound(json);
            }
            else
            {
                return Ok(json);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeletePet(id));
            var json = JsonSerializer.Serialize(response);
            if (response["succes"].Equals(false))
            {
                return BadRequest(json);
            }
            else
            {
                return Ok(json);
            }


        }
    }
}
