using Microsoft.AspNetCore.Mvc;

namespace W2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
