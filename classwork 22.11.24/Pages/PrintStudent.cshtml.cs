using classwork_22._11._24.Data;
using classwork_22._11._24.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace classwork_22._11._24.Pages
{
    public class PrintStudentModel : PageModel
    {
        private readonly DataContext _context;

		public PrintStudentModel(DataContext context)
		{
			_context = context;
		}

        public Book Book { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            Book = book;

            return Page();
        }

        public IActionResult OnGetReturn()
        {
            return RedirectToPage("Index");
        }
    }
}
