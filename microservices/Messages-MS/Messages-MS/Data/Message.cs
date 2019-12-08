using System;

namespace Messages_MS.Data
{
    public class Message
    {
        public Guid Id { get; private set; }

        public Guid SenderId { get; private set; }

        public Guid ReceiverId { get; private set; }

        public string Text { get; private set; }

        public DateTime CreatedAt { get; private set; }

        private Message()
        {

        }

        public static Message Create(Guid senderId, Guid receiverId, string text, DateTime createdAt)
        {
            return new Message
            {
                Id = Guid.NewGuid(),
                SenderId = senderId,
                ReceiverId = receiverId,
                Text = text,
                CreatedAt = createdAt
            };
        }

    }
}
