using System.Threading.Tasks;

namespace MicroservicesApp.MessageBus
{
    public interface IMessageBus
    {
        Task PublishMessage(BaseMessage message, string topicName);
    }
}
