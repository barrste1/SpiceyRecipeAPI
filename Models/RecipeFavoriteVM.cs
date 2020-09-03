using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiceyRecipeAPI.Models
{
    public class RecipeFavoriteVM: Result
    {
        public bool isFavorite { get; set; }
    }
}
