using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace testProject1.Pages
{
	public class LoginModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Message"] = string.Empty;
        }
        public void OnPost(string t1,string gender)
        {
            ViewData["Message"] = $"Welcome. {gender} {t1}";
        }
    }
}
