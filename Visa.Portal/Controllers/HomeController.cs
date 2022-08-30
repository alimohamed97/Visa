using Microsoft.AspNetCore.Mvc;

namespace Visa.Portal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
