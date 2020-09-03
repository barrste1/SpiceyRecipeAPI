using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiceyRecipeAPI.Models
{
    public class RecipeFavoriteVM : Result
    {
        public bool isFavorite { get; set; }

        public RecipeFavoriteVM() { }
        public RecipeFavoriteVM(string title, string href, string ingredients, string thumbnail) :base(title,href,ingredients,thumbnail)
        {

        }
    }
}
