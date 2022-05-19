using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EfCoreApp02;

namespace EfCoreApp02.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly EfCoreApp02.ProductsDBContext _context;

        public DeleteModel(EfCoreApp02.ProductsDBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TblProduct TblProduct { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }

            var tblproduct = await _context.TblProducts.FirstOrDefaultAsync(m => m.Id == id);

            if (tblproduct == null)
            {
                return NotFound();
            }
            else 
            {
                TblProduct = tblproduct;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }
            var tblproduct = await _context.TblProducts.FindAsync(id);

            if (tblproduct != null)
            {
                TblProduct = tblproduct;
                _context.TblProducts.Remove(TblProduct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
