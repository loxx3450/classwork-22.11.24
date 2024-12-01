using classwork_22._11._24.Data;
using classwork_22._11._24.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace classwork_22._11._24.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, DataContext context)
        {
            _logger = logger;
            _context = context;

            Books = [];
        }

        public List<Book> Books { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? TitlePattern { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? AuthorPattern { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var books = _context.Books.AsNoTracking();

            if (! string.IsNullOrEmpty(TitlePattern))
            {
                books = books.Where(b => b.Title.Contains(TitlePattern));
            }    
            if (! string.IsNullOrEmpty(AuthorPattern))
            {
                books = books.Where(b => b.AuthorFullName.Contains(AuthorPattern));
            }

            Books = await books.ToListAsync();

            return Page();
        }

        public IActionResult OnGetAddBook()
        {
            return RedirectToPage("AddBook");
        }

        public IActionResult OnGetResetFilter()
        {
            TitlePattern = null;
            AuthorPattern = null;

            return RedirectToPage("Index");
        }

        //public IActionResult OnGetPrintStudent(int id)
        //{
        //    return RedirectToPage("PrintStudent", id);
        //}
    }
}
