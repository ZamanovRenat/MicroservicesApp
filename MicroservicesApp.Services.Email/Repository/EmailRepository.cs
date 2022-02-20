using System;
using System.Threading.Tasks;
using MicroservicesApp.Services.Email.DbContexts;
using MicroservicesApp.Services.Email.Messages;
using MicroservicesApp.Services.Email.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesApp.Services.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContext;

        public EmailRepository(DbContextOptions<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SendAndLogEmail(UpdatePaymentResultMessage message)
        {
            //implement an email sender or call some other class library
            /*
             * public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
 
            emailMessage.From.Add(new MailboxAddress("Inst", "some@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("Inst", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
 
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync("*********@yandex.ru", System.Environment.GetEnvironmentVariable("*********"));
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
             */
            EmailLog emailLog = new EmailLog()
            {
                Email = message.Email,
                EmailSent = DateTime.Now,
                Log = $"Order - {message.OrderId} has been created successfully."
            };

            await using var _db = new ApplicationDbContext(_dbContext);
            _db.EmailLogs.Add(emailLog);
            await _db.SaveChangesAsync();
        }
    }
}
