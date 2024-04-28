using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class ChatRoomController : Controller
{
    private readonly Dictionary<string, ChatRoom> _chatRooms = new Dictionary<string, ChatRoom>();

    public ChatRoomController()
    {
        // Initialize mock chat rooms with sample messages
        _chatRooms.Add("lecture1_chat", new ChatRoom
        {
            Id = 1,
            Name = "Lecture Chat Room",
            Messages = new List<ChatMessage>
            {
                new ChatMessage { Id = 1, Content = "Hello everyone!", Timestamp = DateTime.Now.AddMinutes(-15), SenderName = "Anonymous", Upvotes = 3 },
                new ChatMessage { Id = 2, Content = "How's everyone finding the lecture?", Timestamp = DateTime.Now.AddMinutes(-10), SenderName = "Anonymous", Upvotes = 1 }
            }
        });

        _chatRooms.Add("lab1_chat", new ChatRoom
        {
            Id = 2,
            Name = "Lab Chat Room",
            Messages = new List<ChatMessage>
            {
                new ChatMessage { Id = 1, Content = "Welcome to the lab!", Timestamp = DateTime.Now.AddMinutes(-20), SenderName = "Anonymous", Upvotes = 2 },
                new ChatMessage { Id = 2, Content = "Has anyone completed the lab exercise?", Timestamp = DateTime.Now.AddMinutes(-10), SenderName = "Anonymous", Upvotes = 0 }
            }
        });
    }

    public IActionResult Index(string chatRoomId)
    {
        if (_chatRooms.ContainsKey(chatRoomId))
        {
            var chatRoom = _chatRooms[chatRoomId];
            return View(chatRoom);
        }

        return NotFound();
    }
}
