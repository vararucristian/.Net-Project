﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Likes_MS.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Likes_MS.Controllers
{
    [Route("api/likes")]
    [ApiController]
    public class LikesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public LikesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // GET: api/Likes/5
        [HttpGet("{PersonId}/{petOwnerId}")]
        public string GetByIds(Guid PersonId , Guid petOwnerId)
        {
            var response = _mediator.Send(new GetLikeByIdsQuery(PersonId, petOwnerId));
            var json = JsonSerializer.Serialize(response);
            return json;
        }


        // GET: api/Likes/5
        [HttpGet("{Id}")]
        public string GetFullLikebyId(Guid Id)
        {
            var response = _mediator.Send(new GetFullLikeByIdQuery(Id));
            var json = JsonSerializer.Serialize(response.Result);
            return json;
        }

        // POST: api/Likes
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateLike jsonRequest)
        {
            var response = await _mediator.Send(jsonRequest);
            var json = JsonSerializer.Serialize(response);
            return json;
        }

        // PUT: api/Likes/5
        [HttpPut()]
        public async Task<ActionResult<string>> Put([FromBody] UpdateLike jsonRequest)
        {
            var response = await _mediator.Send(jsonRequest);
            var json = JsonSerializer.Serialize(response);
            return json;
        }

    }
}
