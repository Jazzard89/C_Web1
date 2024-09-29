using Microsoft.AspNetCore.Mvc;
using Slide06ModelValidation.Data;
using Slide06ModelValidation.Models;

namespace Slide06ModelValidation.Controllers
{
    public class TestDataController : Controller
    {
        public IActionResult Index()
        {
            return View(LocalData.TestDataList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var testData = new TestData(); //waarom word testData meegegeven?
            return View(testData);
        }
        [HttpPost]
        public IActionResult Create(TestData testData)
        {
            if (ModelState.IsValid)
            {
                LocalData.TestDataList.Add(testData);
                return RedirectToAction("Index");
            }
            return View(testData);
        }
    }
}
