

namespace MyLibrary.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public string CoverImage { get; set; }

        public ICollection<BorrowerBook> Borrowers { get; set; }
    }
}
