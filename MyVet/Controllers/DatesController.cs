using Microsoft.AspNetCore.Mvc;

namespace MyVet.Controllers
{
    public class DatesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
