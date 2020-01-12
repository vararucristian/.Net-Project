using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.Net.Http;

namespace FrontEnd
{

    
    public class MessageRequest
    {
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Text { get; set; }
    }

    public class Message
    {
        public string Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class MessageResponse
    {
        public bool succes { get; set; }
        public Message message { get; set; }
    }
}
