using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;

namespace MicroservicesApp.MessageBus
{
    public class AzureServiceBusMessageBus : IMessageBus
    {
        //Можно размести в файлах конфигурации
        private string connectionString = "Endpoint=sb://microservicesapp.servicebus.windows.net/;SharedAccessKeyName=MicroservicesAppPolitycs;SharedAccessKey=rH5UVyVGufdkoIEH3m3D2mdgX37q25/BbiW7LuidenY=;EntityPath=checkoutmessagetopic";

        public async Task PublishMessage(BaseMessage message, string topicName)
        {
            await using var client = new ServiceBusClient(connectionString);

            ServiceBusSender sender = client.CreateSender(topicName);

            var jsonMessage = JsonConvert.SerializeObject(message);
            ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString()
            };

            await sender.SendMessageAsync(finalMessage);

            await client.DisposeAsync();
        }
    }
}
