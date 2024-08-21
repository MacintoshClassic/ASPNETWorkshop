using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class ClientController : Controller
{
    // 
    // GET: /Client/
    public IActionResult Index()
    {
        return View();
    }
    // 
    // GET: /Client/Welcome/ 
    public string Welcome(string name, int ID = 1)
    {
        return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
    }
}