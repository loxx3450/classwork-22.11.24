using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTestApp.Models;

namespace RazorPagesTestApp.Pages
{
    public class StudentRowModel : PageModel
    {
        public StudentRowModel()
        {
            
        }

        [BindProperty]
        public Student Student { get; set; }

        public void OnGet()
        {
        }
    }
}
