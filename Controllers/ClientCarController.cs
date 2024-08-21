using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class ClientCarController : Controller
{
    // 
    // GET: /ClientCar/
    public string Index()
    {
        return "This is my default action for ClientCarController...";
    }
    // 
    // GET: /ClientCar/Welcome/ 
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}