
namespace Shared
{
    public class Message
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int UserId { get; set; } = 0;
        public enMessageType MessageType { get; set; }
    }
}
