using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public FoodType FoodType { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            FoodType = _db.FoodType.FirstOrDefault(u=>u.Id==id);
        }

        public async Task<IActionResult> OnPost()
        {
            var foodTypeFromDb = _db.Category.Find(FoodType.Id);
            if (foodTypeFromDb != null)
            {
                _db.Category.Remove(foodTypeFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Food Type deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
