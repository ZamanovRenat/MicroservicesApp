using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroservicesApp.MessageBus;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MicroservicesApp.Services.ShoppingCartAPI.RabbitMQSender
{
    public class RabbitMQCartMessageSender : IRabbitMQCartMessageSender
    {
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _username;
        private IConnection _connection;

        public RabbitMQCartMessageSender()
        {
            _hostname = "localhost";
            _password = "guest";
            _username = "guest";
        }
        public void SendMessage(BaseMessage baseMessage, string queueName)
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };
            _connection = factory.CreateConnection();

            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
            var json = JsonConvert.SerializeObject(baseMessage);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
        }
    }
}
