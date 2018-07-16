using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using MyLibrary.Data;

namespace BookLibrary.Web.Pages.Books
{
    public class DetailsModel : PageModel
    {
        public DetailsModel(LibraryDbContext context)
        {
            this.Context = context;
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public LibraryDbContext Context { get; set; }

        public IActionResult OnGet(int id)
        {
            var book = this.Context.Books
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return this.NotFound();
            }

            this.Title = book.Title;
            this.Description = book.Description;
            this.ImageUrl = book.CoverImage;
            this.Author = book.Author.Name;

            return this.Page();
        }
    }
}