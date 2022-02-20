using System.Threading.Tasks;
using MicroservicesApp.Services.Email.Messages;

namespace MicroservicesApp.Services.Email.Repository
{
    public interface IEmailRepository
    {
        Task SendAndLogEmail(UpdatePaymentResultMessage message);
    }
}
