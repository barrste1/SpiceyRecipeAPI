using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpiceyRecipeAPI.Models;

namespace SpiceyRecipeAPI.Controllers
{
    public class SpiceyRecipeController : Controller
    {
        private readonly SpiceyRecipeDBContext _context;
        public SpiceyRecipeController(SpiceyRecipeDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            SpiceyRecipeDAL dl = new SpiceyRecipeDAL();

            var recipeobj = dl.GetRecipe();
            return View(recipeobj);
        }
    }
}
