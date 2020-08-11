using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindMvc.Models;
using Packt.CS7;

namespace NorthwindMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private Northwind db;
        public HomeController(Northwind injectedContext, ILogger<HomeController> logger)
        {
            _logger = logger;
            db = injectedContext;
        }

        public IActionResult Index()
        {
            //return View();
            var model = new HomeIndexViewModel
            {
                VisitorCount = (new Random()).Next(1, 1001),
                Categories = db.Categories.ToList(),
                Products = db.Products.ToList()
            };
            return View(model); // передача модели представлению
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
