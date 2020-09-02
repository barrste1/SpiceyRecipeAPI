using System;
using System.Collections.Generic;

namespace SpiceyRecipeAPI.Models
{
    public partial class Favorite
    {
        public Favorite()
        {
            UsersFavorite = new HashSet<UsersFavorite>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string RecipeLink { get; set; }
        public string Ingredients { get; set; }
        public string Thumbnail { get; set; }

        public virtual ICollection<UsersFavorite> UsersFavorite { get; set; }
    }
}
