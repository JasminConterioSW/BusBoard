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


            var jsonResponse = GetBusTimesJsonFromTflApi(busStopCode);

            //Console.WriteLine(jsonResponse);

            //DeserializeJson(jsonResponse);

            return nextBuses;
        }

        public static List<Bus> GetBusTimesJsonFromTflApi(string busStopCode)
        {
            var Client = new RestClient("https://api.tfl.gov.uk/");
            var request = new RestRequest($"StopPoint/{busStopCode}/Arrivals", DataFormat.Json);
            var response = Client.Execute<List<Bus>>(request).Data;
            //Console.WriteLine(response);
            
            foreach (var bus in response)
            {
                Console.WriteLine(bus.TimeToStation);
                Console.WriteLine(bus.DestinationName);
                Console.WriteLine(bus.LineName);
            }
            return response;
        }
        
        public static void DeserializeJson(string jsonString)
        {

            // dynamic data = JsonSerializer.Deserialize<dynamic>(jsonString);
            // foreach (var obj in data)
            // {
            //     Bus bus = new Bus()
            //     {
            //         TimeToStation = obj.timeToStation,
            //         LineName = obj.lineName,
            //         DestinationName = obj.destinationName
            //     };
            // }


            var newBusList =
                JsonSerializer.Deserialize<List<Bus>>(jsonString); //this bit isn't working yet
            //     Console.WriteLine(newBusList);
            //     foreach (var bus in newBusList)
            //     {
            //         Console.WriteLine(bus.TimeToStation);
            //     }
            //
            // }

            //
            //
            //
            // public Bus( int timeToStation, string destinationName, string lineName)
            // {
            //     TimeToStationInSeconds = timeToStation;
            //     Destination = 
            //     
            // }
        }
    }
}


