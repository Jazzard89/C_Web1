﻿using Microsoft.AspNetCore.Mvc;

namespace ShopApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
