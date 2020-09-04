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

        public string CallAPI(string input)
        {   //sets up our request           
            HttpWebRequest request = WebRequest.CreateHttp($"http://www.recipepuppy.com/api/?{input}");

            //This sends us the response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string output = rd.ReadToEnd();

            return output;
        }


        public List<Result> GetRecipe(string input)
        {

            string recipeJson = CallAPI(input);

            JObject json = JObject.Parse(recipeJson);

            List<JToken> data = json["results"].ToList();
           
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
