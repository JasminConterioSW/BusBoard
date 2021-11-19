using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using RestSharp;
using System.Text.Json;

namespace BusBoard1

{
    public class TflApi
    {

        
        public static List<string> GetBusTimes(string busStopCode, int nBusses)
        {
            List<string> nextBusses = new List<string>();


            string jsonResponse = GetBusTimesJsonFromTflApi(busStopCode);
            
            //Console.WriteLine(jsonResponse);

            DeserializeJson(jsonResponse);

            return nextBusses;
        }

        public static string GetBusTimesJsonFromTflApi(string busStopCode)
        {
            var Client = new RestClient("https://api.tfl.gov.uk/");
            var request = new RestRequest($"StopPoint/{busStopCode}/Arrivals", DataFormat.Json);
            var response = Client.Get(request);
            
            return response.Content;
        }

        public static void DeserializeJson(string jsonString)
        {
            List<Bus> newBusList = 
                 JsonSerializer.Deserialize<List<Bus>>(jsonString);  //this bit isn't working yet
            //Console.WriteLine(newBusList);

            foreach (var bus in newBusList)
            {
                Console.WriteLine(bus.timeToStation);
            }

            // public Bus( int timeToStation, string destinationName, string lineName)
            // {
            //     TimeToStationInSeconds = timeToStation;
            //     Destination = 
            //     
            // }
        }
    }

    



}

