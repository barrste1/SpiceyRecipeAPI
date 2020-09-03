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

        public string CallAPI()
        {   //sets up our request
            HttpWebRequest request = WebRequest.CreateHttp($"http://www.recipepuppy.com/api/");

            //This sends us the response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string output = rd.ReadToEnd();

            return output;
        }


        public RecipepuppyObject GetRecipe()
        {
            //var client = GetClient();
            //var response = await client.GetAsync("/?q=chicken");
            //RecipepuppyObject puppyObject = await response.Content.ReadAsAsync<RecipepuppyObject>();

            string recipeJson = CallAPI();

            //Takes JSON data and puts into a JSON object --- a series of nested properties
            //Javascript has an advantage since JSON is simply a Javascript
            //JObject wasn't recognized and need an install of a nuget package
            JObject json = JObject.Parse(recipeJson);


            RecipepuppyObject recipeObject = JsonConvert.DeserializeObject<RecipepuppyObject>(json.ToString());
            //List<JToken> data = json["data"]["children"].ToList();

            return recipeObject;


        }
    }
}
