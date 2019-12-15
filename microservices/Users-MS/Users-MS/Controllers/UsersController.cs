using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Users_Ms.Business.Commands;
using System.Text.Json;
using System;
using Users_MS.DTO;
using Users_Ms.Data;

namespace Users_Ms.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {

            _mediator = mediator;

        }

        [HttpGet]
        public async Task<ActionResult<string>> GetAllUsersAsync()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            var json = JsonSerializer.Serialize(users);
            return json;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetUsersByIdAsync(Guid id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(id));
            var json = JsonSerializer.Serialize(response);
            if (response["succes"].Equals(false))
            {
                return BadRequest(json);
            }
            return json;
        }

        [HttpGet("username/{userName}")]
        public async Task<ActionResult<string>> GetUsersByUserNameAndPassword(string userName)
        {
            var response = await _mediator.Send(new GetUserByUsernameQuery(userName));
            var json = JsonSerializer.Serialize(response);
            if (response["succes"].Equals(false))
            {
                return BadRequest(json);
            }
            return json;
        }


        [HttpGet("{userName}/{password}")]
        public async Task<ActionResult<string>> GetUsersByUserNameAndPassword(string userName, string password)
        {
            var response = await _mediator.Send(new GetUserByUsernameAndPasswordQuery(userName, password));
            var json = JsonSerializer.Serialize(response);
            if (response["succes"].Equals(false))
            {
                return BadRequest(json);
            }
            return json;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody]CreateUser jsonRequest)
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

        [Route("authenticate")]
        [HttpPost("authenticate")]
        public async Task<ActionResult<string>> Authenticate([FromBody]AuthenticateUser jsonRequest)
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


        [HttpPut]
        public async Task<ActionResult<string>> Update([FromBody]UPdateUser jsonRequest)
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


        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteUser(id));
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