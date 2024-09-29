using Microsoft.AspNetCore.Mvc;
using Slide7.Data;
using Slide7.Models;

namespace Slide7.Controllers
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
            var testData = new TestData();
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
