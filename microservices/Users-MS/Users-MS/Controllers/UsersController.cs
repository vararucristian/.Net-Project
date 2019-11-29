﻿using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Users_Ms.Business.Commands;
using System.Text.Json;
using System;

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
        
    }



}