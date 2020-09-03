using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpiceyRecipeAPI.Models;

namespace SpiceyRecipeAPI.Controllers
{
    public class HomeController : Controller
    {
        //private readonly SpiceyRecipeDAL _spiceyRecipeDAL;

        //public HomeController()
        //{
        //    _spiceyRecipeDAL = new SpiceyRecipeDAL();
        //}
        public IActionResult Index()
        {
            return View();
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
