using System;
using MicroservicesApp.MessageBus;

namespace MicroservicesApp.Services.ShoppingCartAPI.RabbitMQSender
{
    public interface IRabbitMQCartMessageSender
    {
        void SendMessage(BaseMessage baseMessage, String queueName);
    }
}
