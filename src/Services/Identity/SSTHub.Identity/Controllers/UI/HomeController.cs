using Microsoft.AspNetCore.Mvc;

namespace SSTHub.Identity.Controllers.UI
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
