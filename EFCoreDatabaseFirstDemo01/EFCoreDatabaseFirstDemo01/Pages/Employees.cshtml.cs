using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreDatabaseFirstDemo01.Pages
{
	public class EmployeesModel : PageModel
    {
        EmpDBContext context = new EmpDBContext();
        public void OnGet()
        {
            ViewData["Employees"] = context.TblEmployees.ToList();
        }
    }
}
