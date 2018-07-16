namespace MyLibrary.Models.Models
{
    public class BorrowerBook
    {
        public int BorrowerId { get; set; }

        public Borrower Borrower { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}