using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpiceyRecipeAPI.Models
{
    public class SpiceyRecipeDAL
    {
        public HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://www.recipepuppy.com/api"); ///?q=chicken
            return client;
        }

        public async Task<string> GetRecipe()
        {
            var client = GetClient();
            var response = await client.GetAsync("/?q=chicken");
            string recipepuppyObject = await response.Content.ReadAsStringAsync();
            return recipepuppyObject;
        }
    }
}
