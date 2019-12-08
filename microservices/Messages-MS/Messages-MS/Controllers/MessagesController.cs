using System;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using Messages_MS.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Messages_MS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<string>> GetAllMessagesAsync()
        {
            var messages = await _mediator.Send(new GetMessagesQuery());
            var json = JsonSerializer.Serialize(messages);

            return json;
        }

        // GET: api/Messages/receiverId/...
        [HttpGet("receiverId/{receiverId}")]
        public async Task<ActionResult<string>> GetMessagesByReceiverIdAsync(Guid receiverId)
        {
            var messages = await _mediator.Send(new GetMessagesByReceiverIdQuery(receiverId));
            var json = JsonSerializer.Serialize(messages);

            return json;
        }

        // GET: api/Messages/senderId/...
        [HttpGet("senderId/{senderId}")]
        public async Task<ActionResult<string>> GetMessagesBySenderIdAsync(Guid senderId)
        {
            var messages = await _mediator.Send(new GetMessagesBySenderIdQuery(senderId));
            var json = JsonSerializer.Serialize(messages);

            return json;
        }


        // GET: api/Messages/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Messages
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody]CreateMessage jsonRequest)
        {
            var response = await _mediator.Send(jsonRequest);
            var json = JsonSerializer.Serialize(response);

            return json;
        }

        // PUT: api/Messages/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid id)
        {
            var message = await _mediator.Send(new DeleteMessage(id));
            var json = JsonSerializer.Serialize(message);
            return json;
        }
    }
}
