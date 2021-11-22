namespace BusBoard1.Api.Apis
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