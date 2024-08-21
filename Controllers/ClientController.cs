using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class ClientController : Controller
{
    // 
    // GET: /Client/
    public string Index()
    {
        return "This is my default action for ClientController...";
    }
    // 
    // GET: /Client/Welcome/ 
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}