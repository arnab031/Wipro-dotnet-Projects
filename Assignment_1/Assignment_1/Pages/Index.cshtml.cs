using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment_1.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        ViewData["Message"] = string.Empty;
    }
    public void OnPost(string b1)
    {
        string msg = "";
        if (b1 == "create")
        {
            msg = "Create";
        }else if (b1 == "retreive")
        {
            msg = "Retreive";
        }else if (b1 == "update")
        {
            msg = "Update";
        }else if (b1 == "delete")
        {
            msg = "Delete";
        }
        ViewData["Message"] = msg + " is clicked";
    }
}

