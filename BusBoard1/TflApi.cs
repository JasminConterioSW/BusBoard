using System.Collections.Generic;
using System.Net.Http.Json;
using RestSharp;

namespace BusBoard1

{
    public class TflApi
    {

        /*public void GetBusTimesJsonFromTflApi(string busStopCode)
        {
            public RestClient Client = new RestClient("https://api.tfl.gov.uk/");
            RestRequest request = new RestRequest("StopPoint/490008660N/Arrivals", DataFormat.Json);
            var response = Client.Get(request);
            
            
        }*/
        
        public static List<string> GetBusTimes(string busStopCode, int nBusses)
        {
            List<string> nextBusses = new List<string>();
            
            
            

            return nextBusses;
        }

        // {
        //
        //     public RestClient Client = new RestClient("https://api.twitter.com/1.1");
        //     
        // //     public void CallApi(string )
        // //
        // // public RestClient Client = new RestClient("https://api.twitter.com/1.1");
        // //
        // // var request = new RestRequest("statuses/home_timeline.json", DataFormat.Json);
        // //
        // // var response = client.Get(request);
        // // #1#
        // }
        
        
    }

    



}

