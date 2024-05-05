using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Shared.Commons;
using Shared.Helpers;
using System.Text;

namespace NotificationSystem_RabbitMQ.RabbitMQ
{
    public class Producer : IProducer
    {
        public void Send<T>(T message)
        {

            var factory = new ConnectionFactory
            {
                Uri = new Uri(AppSettings.Instance.RabbitMQURL)
            };

            var connection = factory.CreateConnection();
            
            using var channel = connection.CreateModel();
            
            channel.QueueDeclare(CustomContants.ROUTING_KEY, exclusive: false);
            
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            
            channel.BasicPublish(exchange: "", routingKey: CustomContants.ROUTING_KEY, body: body);
        }
    }
}
