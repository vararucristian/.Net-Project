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
    [Route("api/[controller]")]
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
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            var json = JsonSerializer.Serialize(user);
            return json;
        }

        [HttpGet("{userName}/{password}")]
        public async Task<ActionResult<string>> GetUsersByUserNameAndPassword(string userName,string password)
        {
            var user = await _mediator.Send(new GetUserByUsernameAndPasswordQuery(userName,password));
            var json = JsonSerializer.Serialize(user);
            return json;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody]CreateUser jsonRequest)
        {

            var user = await _mediator.Send(jsonRequest);
            var json = JsonSerializer.Serialize(user);
            return json;

        }

        [HttpPut]
        public async Task<ActionResult<string>> Update([FromBody]UpdateUser jsonRequest)
        {

            var user = await _mediator.Send(jsonRequest);
            var json = JsonSerializer.Serialize(user);
            return json;

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid id)
        {

            var user = await _mediator.Send(new DeleteUser(id));
            var json = JsonSerializer.Serialize(user);
            return json;
        }
    }



}