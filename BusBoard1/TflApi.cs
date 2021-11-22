using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using RestSharp;
using System.Text.Json;
using System.Dynamic;
using System.Text.Json.Serialization;
using System.Linq;

namespace BusBoard1

{
    public class TflApi
    {

        public static List<string> GetBusTimes(string busStopCode, int nBusses)
        {
            List<string> nextBuses = new List<string>();
            
            var busList = GetBusTimesJsonFromTflApi(busStopCode);
            PrintBusTimes(busList, nBusses);

            return nextBuses;
        }

        private static List<Bus> GetBusTimesJsonFromTflApi(string busStopCode)
        {
            var client = new RestClient("https://api.tfl.gov.uk/");
            var request = new RestRequest($"StopPoint/{busStopCode}/Arrivals", DataFormat.Json);
            var response = client.Execute<List<Bus>>(request).Data;

            return response;
        }

        private static void PrintBusTimes(List<Bus> busList, int nBusses)
        {

            List<Bus> sorted = busList.OrderBy(b => b.TimeToStation).ToList();
            var nSorted = sorted.Take(nBusses);
            
            foreach (var bus in nSorted)
            {
                Console.WriteLine(
                    $"Bus route {bus.LineName} to {bus.DestinationName} will arrive in {bus.TimeToStation / 60} minutes");
                
            }
        }
        
       
    }
}


