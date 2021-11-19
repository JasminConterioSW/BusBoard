using RestSharp;

namespace BusBoard1
{
    public class TflApi
    {
        
        public RestClient Client = new RestClient("https://api.twitter.com/1.1");
        
        var request = new RestRequest("statuses/home_timeline.json", DataFormat.Json);
        
        var response = client.Get(request);
    }
}