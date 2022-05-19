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
    public class IndexModel : PageModel
    {
        private readonly EfCoreApp02.ProductsDBContext _context;

        public IndexModel(EfCoreApp02.ProductsDBContext context)
        {
            _context = context;
        }

        public IList<TblProduct> TblProduct { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TblProducts != null)
            {
                TblProduct = await _context.TblProducts.ToListAsync();
            }
        }
    }
}
