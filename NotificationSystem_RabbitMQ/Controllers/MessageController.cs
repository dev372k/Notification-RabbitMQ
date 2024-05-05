using Microsoft.AspNetCore.Mvc;
using NotificationSystem_RabbitMQ.RabbitMQ;
using Shared;

namespace NotificationSystem_RabbitMQ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IProducer _producer;

        public MessageController(IProducer producer)
        {
            _producer = producer;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Message request)
        {
            _producer.Send(request);
            return Ok(new {Message = "Message has been sent successfully."});
        }
    }
}
