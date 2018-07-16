namespace MyLibrary.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Models.Models;

    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(book => book.Borrowers)
                .WithOne(borrower => borrower.Book)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Borrower>()
                .HasMany(borrower => borrower.BorrowedBooks)
                .WithOne(book => book.Borrower)
                .HasForeignKey(b => b.BorrowerId);

            modelBuilder.Entity<BorrowerBook>()
                .HasKey(b => new { b.BookId, b.BorrowerId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
