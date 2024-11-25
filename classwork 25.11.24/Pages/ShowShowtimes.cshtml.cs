using classwork_25._11._24.Data;
using classwork_25._11._24.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace classwork_22._11._24.Pages
{
    public class ShowShowtimesModel : PageModel
    {
        private readonly DataContext _context;

        public ShowShowtimesModel(DataContext context)
        {
            _context = context;
        }

        public List<Showtime> Showtimes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _context.Movies.Include(m => m.Showtimes).FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null) 
                return NotFound();

            Showtimes = movie.Showtimes;

            return Page();
        }


    }
}
