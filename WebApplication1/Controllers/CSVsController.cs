using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class CSVsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
