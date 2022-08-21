using Microsoft.AspNetCore.Mvc;

namespace FIS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
