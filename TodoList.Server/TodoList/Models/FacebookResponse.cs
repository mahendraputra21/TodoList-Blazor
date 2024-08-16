namespace TodoList.Server.TodoList.Models
{
    public class FacebookResponse
    {
        public string Message { get; set; }
        public string FacebookId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public FacebookResponse(string message, string facebookId, string email, string name)
        {
            Message = message;
            FacebookId = facebookId;
            Email = email;
            Name = name;
        }
    }
}
