using BusBoard1.Api.Models;
using RestSharp;

namespace BusBoard1.Api.Clients
{
    public class PostCodeApi
    {
        public LongLat GetLongLatFromPostCodeApi(string postCode)
        {
            var client = new RestClient("http://api.postcodes.io/");
            var request = new RestRequest($"postcodes/{postCode}", DataFormat.Json);
            var response = client.Get<PostcodeResponse>(request).Data.Result;
            
            return response;
            
        }
    }
}