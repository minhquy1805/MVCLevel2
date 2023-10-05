using Microsoft.AspNetCore.Mvc;

namespace DuAnTuyetVoiPart1.Controllers
{
    public class IntroductionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Aptech()
        {
            return View();
        }
    }
}
