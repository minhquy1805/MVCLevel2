using Microsoft.AspNetCore.Mvc;

namespace DuAnTuyetVoiPart1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
