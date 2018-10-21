namespace IRunes.Models
{
    public class User : BaseEntity<string>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}