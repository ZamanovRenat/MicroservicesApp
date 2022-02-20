using System.Threading.Tasks;

namespace MicroservicesApp.Services.Email.Messaging
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();
        Task Stop();
    }
}
