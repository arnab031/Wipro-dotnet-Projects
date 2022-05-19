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
    public class DetailsModel : PageModel
    {
        private readonly EfCoreApp02.ProductsDBContext _context;

        public DetailsModel(EfCoreApp02.ProductsDBContext context)
        {
            _context = context;
        }

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
    }
}
