using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using MicroservicesApp.Services.OrderAPI.Messages;
using Newtonsoft.Json;

namespace MicroservicesApp.Services.OrderAPI.Messaging
{
    public class AzureServiceBusConsumer
    {
        private async Task OnCheckOutMessageReceived(ProcessMessageEventArgs args)
        {
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);

            CheckoutHeaderDto checkoutHeaderDto = JsonConvert.DeserializeObject<CheckoutHeaderDto>(body);

        }
    }
}
