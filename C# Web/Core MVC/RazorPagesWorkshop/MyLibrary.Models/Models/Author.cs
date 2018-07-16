namespace MyLibrary.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Author
    {
        public Author()
        {
            this.Books = new List<Book>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}