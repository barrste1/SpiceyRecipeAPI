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
        public SpiceyRecipeController(SpiceyRecipeDBContext context)
        {
            _context = context;
        }
        string loginUserId;

        public IActionResult Index(string input)
        {
            SpiceyRecipeDAL dl = new SpiceyRecipeDAL();

            List<Result> results = dl.GetRecipe(input);
            List<RecipeFavoriteVM> displayList = new List<RecipeFavoriteVM>();
            UserFavoriteVM favorites = GetFavorites();

            for(int i =0; i < results.Count; i++)
            {
                displayList.Add(results[i]);
                for(int j =0; j < favorites.favorites.Count; j++)
                {
                    if (results[i].title == favorites.favorites[j].Title)
                    {

                    }
                }
            }


            return View(displayList);
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


    }
}
