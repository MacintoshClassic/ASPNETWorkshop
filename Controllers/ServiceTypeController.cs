using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class ServiceTypeController : Controller
{
    // 
    // GET: /ServiceType/
    public string Index()
    {
        return "This is my default action for ServiceTypeController...";
    }
    // 
    // GET: /ServiceType/Welcome/ 
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}