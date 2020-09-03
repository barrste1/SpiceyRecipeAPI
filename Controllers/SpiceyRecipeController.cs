using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpiceyRecipeAPI.Models;

namespace SpiceyRecipeAPI.Controllers
{
    public class SpiceyRecipeController : Controller
    {
        private readonly SpiceyRecipeDBContext _context;
        string loginUserId;
        public SpiceyRecipeController(SpiceyRecipeDBContext context)
        {
            _context = context;
        }

        
        public IActionResult Index(string input)
        {
            // Get all the recipes from the API
            SpiceyRecipeDAL dl = new SpiceyRecipeDAL();
            List<Result> resultList = dl.GetRecipe(input);
            // Get all the favorites from the db for the login user
            UserFavoriteVM userFavoriteVM = GetFavorites();
            // Build display list
            List<RecipeFavoriteVM> recipeWithFavInfo = new List<RecipeFavoriteVM>();
            foreach (Result item in resultList)
            {
                RecipeFavoriteVM recipeFavoriteVM = new RecipeFavoriteVM();
                recipeFavoriteVM.title = item.title;
                recipeFavoriteVM.href = item.href;
                recipeFavoriteVM.ingredients = item.ingredients;
                recipeFavoriteVM.thumbnail = item.thumbnail;


                Favorite fav = userFavoriteVM.favorites.Where(f => f.Title == item.title).FirstOrDefault();
                if(fav != null)
                {                    
                    recipeFavoriteVM.isFavorite = true;                    
                }
                else
                {
                    recipeFavoriteVM.isFavorite = false;
                }
                recipeWithFavInfo.Add(recipeFavoriteVM);
            }

   
            return View(recipeWithFavInfo);
            //return View(resultList);
        }

        public UserFavoriteVM GetFavorites()
        {
            // Get the login user id
            loginUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            // get all the favorite recipes of the logged in user
            List<UsersFavorite> userFavList = _context.UsersFavorite.ToList().Where(uf => uf.UserId == loginUserId).ToList();

            // create a new list to store all the favorite items
            List<Favorite> favorites = new List<Favorite>();

            // add the items to the list
            foreach (UsersFavorite item in userFavList)
            {
                Favorite favorite = _context.Favorite.Find(item.FavoriteId);
                favorites.Add(favorite);
            }

            // load these details into the view model
            UserFavoriteVM userFavoriteVM = new UserFavoriteVM();
            userFavoriteVM.UserId = loginUserId;
            userFavoriteVM.favorites = favorites;
            return userFavoriteVM;
        }

        
        public IActionResult AddToFavorites(RecipeFavoriteVM result)
        {
            Favorite newFavorite = new Favorite();

            //List<RecipeFavoriteVM> tempdata = (List<RecipeFavoriteVM>)TempData["Results"];
            //List<RecipeFavoriteVM> tempdata = TempData["Results"];
            //var result = tempdata[index];
            newFavorite.Title = result.title;
            newFavorite.RecipeLink = result.href;
            newFavorite.Ingredients = result.ingredients;
            newFavorite.Thumbnail = result.thumbnail;
                        
            _context.Favorite.Add(newFavorite);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}
