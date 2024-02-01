using Microsoft.AspNetCore.Mvc;

namespace WebAdminSPA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
