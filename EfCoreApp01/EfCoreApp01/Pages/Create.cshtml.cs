using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EfCoreApp01;

namespace EfCoreApp01.Pages
{
    public class CreateModel : PageModel
    {
        private readonly EfCoreApp01.EmployeeDBContext _context;

        public CreateModel(EfCoreApp01.EmployeeDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TblEmployee TblEmployee { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TblEmployees == null || TblEmployee == null)
            {
                return Page();
            }

            _context.TblEmployees.Add(TblEmployee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
