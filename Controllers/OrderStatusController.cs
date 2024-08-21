using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class OrderStatusController : Controller
{
    // 
    // GET: /OrderStatus/
    public string Index()
    {
        return "This is my default action for OrderStatusController...";
    }
    // 
    // GET: /OrderStatus/Welcome/ 
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}