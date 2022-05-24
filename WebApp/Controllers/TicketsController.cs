using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class TicketsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


    }
}
