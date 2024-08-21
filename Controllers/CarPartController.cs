using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class CarPartController : Controller
{
    // 
    // GET: /CarPart/
    public string Index()
    {
        return "This is my deaulft action for CarPartController...";
    }
    // 
    // GET: /CarPart/Welcome/ 
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}