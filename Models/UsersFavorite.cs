using System;
using System.Collections.Generic;

namespace SpiceyRecipeAPI.Models
{
    public partial class UsersFavorite
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? FavoriteId { get; set; }

        public virtual Favorite Favorite { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
