using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class ServiceTicketController : Controller
{
    // 
    // GET: /ServiceTicket/
    public string Index()
    {
        return "This is my default action for ServiceTicketController...";
    }
    // 
    // GET: /ServiceTicket/Welcome/ 
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}