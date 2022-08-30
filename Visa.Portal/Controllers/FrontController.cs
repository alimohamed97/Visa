using Microsoft.AspNetCore.Mvc;

namespace Visa.Portal.Controllers
{
    public class FrontController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
