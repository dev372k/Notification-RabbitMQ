using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace NotificationSystem_RabbitMQ.RabbitMQ
{
    public class Producer : IProducer
    {
        public void SendProductMessage<T>(T message)
        {

            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqps://rpjhbfsm:ueK0C5Kll6Ji4b2Oq5fByRFMzGe6pCxv@shrimp.rmq.cloudamqp.com/rpjhbfsm")
            };

            var connection = factory.CreateConnection();
            
            using var channel = connection.CreateModel();
            
            channel.QueueDeclare("message", exclusive: false);
            
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            
            channel.BasicPublish(exchange: "", routingKey: "message", body: body);
        }
    }
}
