public class ChatMessage
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
    public string SenderName { get; set; }
    public int Upvotes { get; set; }
    public int ChatRoomId { get; set; }
}
