using System;
using System.Collections.Generic;
using System.Text.Json;
using BusBoard1.Models;
using RestSharp;

namespace BusBoard1
{
    public class PostCodeApi
    {
        public PostCode GetLongLatFromPostCodeApi(string postCode)
        {
            var client = new RestClient("http://api.postcodes.io/");
            var request = new RestRequest($"postcodes/{postCode}", DataFormat.Json);
            var response = client.Get<PostcodeResponse>(request).Data.Result;
            
            return response;
            
        }
    }
}