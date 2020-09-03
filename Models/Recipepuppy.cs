using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiceyRecipeAPI.Models
{  
    public class RecipepuppyObject
    {
        public string title { get; set; }
        public float version { get; set; }
        public string href { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string title { get; set; }
        public string href { get; set; }
        public string ingredients { get; set; }
        public string thumbnail { get; set; }
        public Result() { }
        public Result(string title, string href, string ingredients, string thumbnail)
        {
            this.title = title; this.href = href; this.ingredients = ingredients; this.thumbnail = thumbnail;
        }
    }




}
