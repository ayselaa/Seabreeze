using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Areas.Admin.Controllers
{

    [Area("admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
