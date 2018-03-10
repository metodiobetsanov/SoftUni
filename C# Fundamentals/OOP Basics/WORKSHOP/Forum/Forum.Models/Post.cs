namespace Forum.Models
{
    using System.Collections.Generic;

    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public int AuthorId { get; set; }

        public ICollection<int> ReplyIds { get; set; }

        public Post(int id, string title, string content, int category, int author, IEnumerable<int> reply)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.CategoryId = category;
            this.AuthorId = author;
            this.ReplyIds = new List<int>(reply);
        }
    }
}