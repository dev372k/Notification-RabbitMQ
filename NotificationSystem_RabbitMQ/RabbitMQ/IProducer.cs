namespace NotificationSystem_RabbitMQ.RabbitMQ
{
    public interface IProducer
    {
        public void Send<T>(T message);
    }
}
