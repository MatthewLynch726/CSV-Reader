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

            using (var streamReader = new StreamReader(UploadedFile.OpenReadStream()))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    // Process each line from the CSV.
                    // For a real CSV, you'd split by commas, handle quotations, etc. 
                    // or use a library like CsvHelper to simplify the parsing.
                }
            }



            return RedirectToAction("Index");

        }


    }
}
