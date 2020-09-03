using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiceyRecipeAPI.Models
{
    public class UserFavoriteVM
    {
        public string UserId { get; set; }
        public List<Favorite> favorites { get; set; }
    }
}
