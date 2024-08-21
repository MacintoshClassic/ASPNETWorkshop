using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class CarController : Controller
{
    // 
    // GET: /Car/
    public string Index()
    {
        return "This is my default action for CarController...";
    }
    // 
    // GET: /Car/Welcome/ 
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}