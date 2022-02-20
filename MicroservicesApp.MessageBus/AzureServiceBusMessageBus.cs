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
        private string connectionString = "Endpoint=sb://microservicesapp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=UFQiYWIkGMC0V+t4VRSFpM7kQbozqk8LNliMqqWR6eQ=";

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
