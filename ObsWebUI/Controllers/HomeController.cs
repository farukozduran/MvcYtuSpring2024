using Microsoft.AspNetCore.Mvc;
using ObsWebUI.Models;
using ObsWebUI.Models.EfDbContext;
using System.Diagnostics;

namespace ObsWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            return View();
        }    
    }
}
