using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using RestSharp;

namespace BusBoard1

{
    public class TflApi
    {

        public static string GetBusTimesJsonFromTflApi(string busStopCode)
        {
            var Client = new RestClient("https://api.tfl.gov.uk/");
            var request = new RestRequest($"StopPoint/{busStopCode}/Arrivals", DataFormat.Json);
            var response = Client.Get(request);

            return response.Content;
        }
        
        public static List<string> GetBusTimes(string busStopCode, int nBusses)
        {
            List<string> nextBusses = new List<string>();


            string jsonResponse = GetBusTimesJsonFromTflApi(busStopCode);
            
            Console.WriteLine(jsonResponse);

            return nextBusses;
        }

        
        
    }

    



}

