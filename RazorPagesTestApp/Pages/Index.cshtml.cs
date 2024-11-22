using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTestApp.Data;
using RazorPagesTestApp.Models;
using System.Linq;

namespace RazorPagesTestApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RazorPagesTestAppContext _context;

        public IndexModel(ILogger<IndexModel> logger, RazorPagesTestAppContext context)
        {
            _logger = logger;
            _context = context;
            Students = new List<Student>();
        }

        [BindProperty]
        public List<Student> Students { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Students = await _context.Student.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            foreach (var student in Students)
            {
                var studentFromDb = await _context.Student.FindAsync(student.Id);
                studentFromDb.PresenceType = student.PresenceType;
                studentFromDb.IsOnline = student.IsOnline;
                studentFromDb.Grade = student.Grade;
                studentFromDb.DiamondCount = student.DiamondCount;
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        public IActionResult OnGetCreateStudent()
        {
            return RedirectToPage("CreateStudent");
        }

        public async Task<IActionResult> OnGetDeleteStudent(int id)
        {
            var student = await _context.Student.FindAsync(id);

            if (student is null)
                return NotFound();

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        //public IActionResult OnGetUpdateStudent(int id)
        //{
        //    return RedirectToPage("UpdateStudent", id);
        //}
    }
}
