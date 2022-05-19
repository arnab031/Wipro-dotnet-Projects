using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EfCoreApp02;

namespace EfCoreApp02.Pages
{
    public class CreateModel : PageModel
    {
        private readonly EfCoreApp02.ProductsDBContext _context;

        public CreateModel(EfCoreApp02.ProductsDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TblProduct TblProduct { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TblProducts == null || TblProduct == null)
            {
                return Page();
            }

            _context.TblProducts.Add(TblProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
