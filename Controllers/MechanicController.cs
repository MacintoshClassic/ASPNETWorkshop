using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class MechanicController : Controller
{
    // 
    // GET: /Mechanic/
    public string Index()
    {
        return "This is my default action for MechanicController...";
    }
    // 
    // GET: /Mechanic/Welcome/ 
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}