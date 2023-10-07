using Microsoft.AspNetCore.Mvc;

namespace DuAnTuyetVoiPart1.Controllers
{
    public class PhotosController : Controller
    {
        public IActionResult PhotosPage()
        {
            return View();
        }
    }
}
