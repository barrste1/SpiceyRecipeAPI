using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpiceyRecipeAPI.Models;

namespace SpiceyRecipeAPI.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly SpiceyRecipeDBContext _context;
        string loginUserId;

        public FavoriteController(SpiceyRecipeDBContext context)
        {

            _context = context;
        }
        public IActionResult Index()
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
            return View(userFavoriteVM);
        }

    


    public IActionResult DeleteFavorite(int favoriteid)
    {
            loginUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
           UsersFavorite deleteItem = _context.UsersFavorite.Where(uf => uf.UserId == loginUserId && uf.FavoriteId == favoriteid).FirstOrDefault();
            
            if (deleteItem != null)
            {
                var foundFavorite = _context.UsersFavorite.Remove(deleteItem);
                _context.SaveChanges();
            }
                return RedirectToAction("Index");
    }

    //public IActionResult SeeFavoritesByUser(int id)
    //{
    //    List<Favorite> favorites = _context.Favorite.Where(x => x.Id == id).ToList();
    //    Favorite favorite = _context.Favorite.Find(id);
    //    RecipeFavoriteVM userFavorites = new RecipeFavoriteVM(id);

    //    return View(userFavorites);
    //}

    //public UserFavoriteVM GetFavorites()
    //{
    //    // Get the login user id
    //    loginUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

    //    // get all the favorite recipes of the logged in user
    //    List<UsersFavorite> userFavList = _context.UsersFavorite.ToList().Where(uf=>uf.UserId==loginUserId).ToList();

    //    // create a new list to store all the favorite items
    //    List<Favorite> favorites = new List<Favorite>();

    //    // add the items to the list
    //    foreach(UsersFavorite item in userFavList)
    //    {
    //        Favorite favorite = _context.Favorite.Find(item.FavoriteId);
    //        favorites.Add(favorite);
    //    }

    //    // load these details into the view model
    //    UserFavoriteVM userFavoriteVM = new UserFavoriteVM();
    //    userFavoriteVM.UserId = loginUserId;
    //    userFavoriteVM.favorites = favorites;
    //    return userFavoriteVM;
    //}
}
}