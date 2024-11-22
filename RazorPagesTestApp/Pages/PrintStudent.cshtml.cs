using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesTestApp.Pages
{
    public class PrintStudentModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
