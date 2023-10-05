using Microsoft.AspNetCore.Mvc;

namespace DuAnTuyetVoiPart1.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Me()
        {
            return View();
        }
    }
}
