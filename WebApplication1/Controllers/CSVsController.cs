using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CSVsController : Controller
    {

        private readonly ApplicationDbContex _db;

        public CSVsController(ApplicationDbContex db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<CSV> objCategoryList = _db.CSVs.ToList();
            return View(objCategoryList);
        }

        [HttpPost]
        public IActionResult Upload(IFormFile UploadedFile) {

            Console.WriteLine("Test!");


            return RedirectToAction("Index");

        }


    }
}
