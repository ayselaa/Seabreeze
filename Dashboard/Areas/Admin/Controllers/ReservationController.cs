using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Areas.Admin.Controllers
{

    [Area("admin")]
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
