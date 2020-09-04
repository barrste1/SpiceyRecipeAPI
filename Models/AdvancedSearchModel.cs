using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiceyRecipeAPI.Models
{
    public class AdvancedSearchModel
    {
        public string querry { get; set; }
        public int ingredientAmount { get; set; }
        public string ingredient1 { get; set; }
        public string ingredient2 { get; set; }
        public string ingredient3 { get; set; }

    }
}
