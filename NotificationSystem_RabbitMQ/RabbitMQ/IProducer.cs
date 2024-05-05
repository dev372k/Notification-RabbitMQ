namespace NotificationSystem_RabbitMQ.RabbitMQ
{
    public interface IProducer
    {
        public void SendProductMessage<T>(T message);
    }
}
