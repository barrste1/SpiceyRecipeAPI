using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpiceyRecipeAPI.Models
{
    public class SpiceyRecipeDAL
    {
        //public HttpClient GetClient()
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://www.recipepuppy.com/api/");


        //    return client;
        //}

        public string CallAPI(string input)
        {   //sets up our request           q={input}
            HttpWebRequest request = WebRequest.CreateHttp($"http://www.recipepuppy.com/api/?{input}");

            //This sends us the response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string output = rd.ReadToEnd();

            return output;
        }


        public List<Result> GetRecipe(string input)
        {
            //var client = GetClient();
            //var response = await client.GetAsync("/?q=chicken");
            //RecipepuppyObject puppyObject = await response.Content.ReadAsAsync<RecipepuppyObject>();

            string recipeJson = CallAPI(input);

            //Takes JSON data and puts into a JSON object --- a series of nested properties
            //Javascript has an advantage since JSON is simply a Javascript
            //JObject wasn't recognized and need an install of a nuget package
            JObject json = JObject.Parse(recipeJson);

            List<JToken> data = json["results"].ToList();
            //RecipepuppyObject recipeObject = JsonConvert.DeserializeObject<RecipepuppyObject>(json.ToString());


            JToken recipeData;
            Result recipepuppy = new Result();
            List<Result> recipes = new List<Result>();
            for (int i = 0; i < data.Count; i++)
            {
                recipeData = data[i];
                recipepuppy = JsonConvert.DeserializeObject<Result>(recipeData.ToString());
                recipes.Add(recipepuppy);
            }

            return recipes;


        }
    }
}
