using Microsoft.AspNetCore.Mvc;

namespace DuAnTuyetVoiPart1.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Software()
        {
            return View();
        }
    }
}
