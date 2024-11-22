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

        public async Task<IActionResult> OnGetAsync()
        {
            Books = await _context.Books.ToListAsync();

            return Page();
        }

        //public IActionResult OnGetPrintStudent(int id)
        //{
        //    return RedirectToPage("PrintStudent", id);
        //}
    }
}
