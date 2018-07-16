using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Models;

namespace MyLibrary.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(LibraryDbContext context)
        {
            this.Context = context;
        }

        public LibraryDbContext Context { get; set; }

        public IEnumerable<BookConciseViewModel> Books { get; set; }

        public void OnGet()
        {
            this.Books = this.Context.Books
                .Include(b => b.Author)
                .OrderBy(b => b.Title)
                .Select(BookConciseViewModel.FromBook)
                .ToList();
        }
    }
}

