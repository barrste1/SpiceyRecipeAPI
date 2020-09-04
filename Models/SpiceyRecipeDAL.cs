using Microsoft.AspNetCore.Mvc.Diagnostics;
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

        public string CallAPI(string input, out bool bResult)
        {   //sets up our request  
            string output = "";
            try 
            {
                HttpWebRequest request = WebRequest.CreateHttp($"http://www.recipepuppy.com/api/?{input}");

           
                //This sends us the response
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                StreamReader rd = new StreamReader(response.GetResponseStream());
            
                output = rd.ReadToEnd();
                bResult = true;
            }
            catch
            {
                bResult = false;
            }
            return output;
        }


        public List<Result> GetRecipe(string input)
        {
            bool bResult;

            string recipeJson = CallAPI(input, out bResult);
            List<Result> recipes = new List<Result>();
           
            if (bResult)
            {


                JObject json = JObject.Parse(recipeJson);

                List<JToken> data = json["results"].ToList();

                JToken recipeData;
                Result recipepuppy = new Result();
               
                for (int i = 0; i < data.Count; i++)
                {
                    recipeData = data[i];
                    recipepuppy = JsonConvert.DeserializeObject<Result>(recipeData.ToString());
                    recipes.Add(recipepuppy);
                }
                
            }
            return recipes;



        }
    }
}
