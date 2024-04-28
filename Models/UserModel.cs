namespace LoginWebApp.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int RelatedId { get; set; } // For students, this will be supervisor ID
    }

}
