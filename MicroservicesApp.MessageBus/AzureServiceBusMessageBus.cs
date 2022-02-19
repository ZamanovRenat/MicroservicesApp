using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;

namespace MicroservicesApp.MessageBus
{
    public class AzureServiceBusMessageBus
    {
        //Можно размести в файлах конфигурации
        private string connectionString = "Endpoint=sb://microservicesapp.servicebus.windows.net/;SharedAccessKeyName=MicroservicesAppPolitycs;SharedAccessKey=rH5UVyVGufdkoIEH3m3D2mdgX37q25/BbiW7LuidenY=;EntityPath=checkoutmessagetopic";

        public async Task PublishMessage(BaseMessage message, string topicName)
        {
            ISenderClient senderClient = new TopicClient(connectionString, topicName);

            var jsonMessage = JsonConvert.SerializeObject(message);
            var finalMessage = new Message(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString()
            };

            await senderClient.SendAsync(finalMessage);

            await senderClient.CloseAsync();
        }
    }
}
