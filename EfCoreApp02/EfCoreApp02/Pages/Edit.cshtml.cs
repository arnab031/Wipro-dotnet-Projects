using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EfCoreApp02;

namespace EfCoreApp02.Pages
{
    public class EditModel : PageModel
    {
        private readonly EfCoreApp02.ProductsDBContext _context;

        public EditModel(EfCoreApp02.ProductsDBContext context)
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

            var tblproduct =  await _context.TblProducts.FirstOrDefaultAsync(m => m.Id == id);
            if (tblproduct == null)
            {
                return NotFound();
            }
            TblProduct = tblproduct;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProductExists(TblProduct.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TblProductExists(int id)
        {
          return (_context.TblProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
