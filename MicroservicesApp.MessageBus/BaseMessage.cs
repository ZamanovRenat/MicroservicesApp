using System;

namespace MicroservicesApp.MessageBus
{
    public class BaseMessage
    {
        public int Id { get; set; }
        public DateTime MessageCreated { get; set; }
    }
}
