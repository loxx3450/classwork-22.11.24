using classwork_25._11._24.Data;
using classwork_25._11._24.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace classwork_25._11._24.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty] 
        public List<Movie> Movies { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Movies = await _context.Movies.ToListAsync();
            return Page();
        }
    }
}
