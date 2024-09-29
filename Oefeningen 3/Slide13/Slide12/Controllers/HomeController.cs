﻿using Microsoft.AspNetCore.Mvc;
using Slide12.Data;
using Slide12.Models;
using Slide12.Repositories;
using System.Diagnostics;

namespace Slide12.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private ProductRepository _repo;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
            _repo = new ProductRepository(_context);
        }

        //public IActionResult Index()
        //{
        //    var products = _context.Products;
        //    return View(products);
        //}
        public IActionResult Index(int id = 1)
        {
            var products = _repo.GetProductModel(id);
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}