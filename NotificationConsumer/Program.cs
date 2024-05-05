using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared;
using System.Text;

var factory = new ConnectionFactory
{
    Uri = new Uri("amqps://rpjhbfsm:ueK0C5Kll6Ji4b2Oq5fByRFMzGe6pCxv@shrimp.rmq.cloudamqp.com/rpjhbfsm")
};

var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare("message", exclusive: false);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var response = Encoding.UTF8.GetString(body);
    var message = JsonConvert.DeserializeObject<Message>(response);

    if (message != null)
    {
        if (message?.MessageType == enMessageType.SMS)
            Console.WriteLine($"Sending sms to: {message.Phone}");
        else if (message?.MessageType == enMessageType.Email)
            Console.WriteLine($"Sending mail to: {message.Email}");
        else
            Console.WriteLine($"No message type specified.");
    }
};

//read the message
channel.BasicConsume(queue: "message", autoAck: true, consumer: consumer);
Console.ReadKey();