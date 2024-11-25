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
            Students = new List<StudentRowModel>();
        }

        [BindProperty]
        public List<StudentRowModel> Students { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("nickname") == null)
            {
                return RedirectToPage("Login");
            }

            Students = await _context.Student
                .Select(s => new StudentRowModel()
                {
                    Student = s
                }).ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            foreach (var student in Students)
            {
                var studentFromDb = await _context.Student.FindAsync(student.Student.Id);
                studentFromDb.PresenceType = student.Student.PresenceType;
                studentFromDb.IsOnline = student.Student.IsOnline;
                studentFromDb.Grade = student.Student.Grade;
                studentFromDb.DiamondCount = student.Student.DiamondCount;
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
