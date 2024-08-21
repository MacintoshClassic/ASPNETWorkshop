using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class ServiceStatusController : Controller
{
    // 
    // GET: /ServiceStatus/
    public string Index()
    {
        return "This is my default action for ServiceStatusController...";
    }
    // 
    // GET: /ServiceStatus/Welcome/ 
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}