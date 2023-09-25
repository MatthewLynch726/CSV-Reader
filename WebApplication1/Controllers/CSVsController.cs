using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
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

       /* [HttpPost]
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
        }*/

        [HttpPost]
        public IActionResult Upload(IFormFile UploadedFile)
        {
            var records = new List<CSV>();

            using (var streamReader = new StreamReader(UploadedFile.OpenReadStream()))
            using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                records = csvReader.GetRecords<CSV>().ToList();
            }

            // Save the records to the database
            _db.CSVs.AddRange(records);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
