using System;
using System.Collections.Generic;
using System.Text.Json;
using RestSharp;

namespace BusBoard1
{
    public class PostCodeApi
    {
        public static Dictionary<string, string> GetLongLatFromPostCodeApi(string postCode)
        {
            var client = new RestClient("http://api.postcodes.io/");
            var request = new RestRequest($"postcodes/{postCode}", DataFormat.Json);
            var response = client.Get(request);
            //Console.WriteLine(response.Content);

            using (JsonDocument document = JsonDocument.Parse(response.Content))
            {
                JsonElement root = document.RootElement;
                JsonElement result = root.GetProperty("result");
                JsonElement longitude = result.GetProperty("longitude");
                JsonElement latitude = result.GetProperty("latitude");
                
                Console.WriteLine(longitude);
                Console.WriteLine(latitude);
                
                var longLatDict = new Dictionary<string, string>
                {
                    { "Latitude", latitude.ToString() },
                    { "Longitude", longitude.ToString() }
                };

                return longLatDict;
            }
        }
    }
}