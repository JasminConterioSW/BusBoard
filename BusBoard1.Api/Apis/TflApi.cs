using System;
using System.Collections.Generic;

namespace BusBoard1.Api.Apis

{
    public class TflApi
    {

        public List<string> GetBusTimes(string busStopCode, int nBusses)
        {
            List<string> nextBuses = new List<string>();
            
            var busList = GetBusses(busStopCode);
            PrintBusTimes(busList, nBusses);

            return nextBuses;
        }

        private List<Bus> GetBusses(string busStopCode)
        {
            var client = new RestClient("https://api.tfl.gov.uk/");
            var request = new RestRequest($"StopPoint/{busStopCode}/Arrivals", DataFormat.Json);
            var response = client.Execute<List<Bus>>(request).Data;

            return response;
        }

        private void PrintBusTimes(List<Bus> busList, int nBusses)
        {

            List<Bus> sorted = busList.OrderBy(b => b.TimeToStation).ToList();
            var nSorted = sorted.Take(nBusses);
            
            foreach (var bus in nSorted)
            {
                Console.WriteLine(
                    $"Bus route {bus.LineName} to {bus.DestinationName} will arrive at {bus.StationName} in {bus.TimeToStation / 60} minutes ");
                
            }
        }

        public List<string> GetBusStopCodesFromLongLat(LongLat longLatObject, int nStops)
        {

            var latitude = longLatObject.Latitude;
            var longitude = longLatObject.Longitude;


            List<string> busStopCodes = GetBusStopCodes(latitude, longitude, nStops);
            
            return busStopCodes;
        }

        private List<string> GetBusStopCodes(string latitude, string longitude, int nStops)
        {
            List<string> busStopCodes = new List<string>();

            var client = new RestClient("https://api.tfl.gov.uk/");
            var request = new RestRequest($"StopPoint/?lat={latitude}&lon={longitude}&stopTypes=NaptanPublicBusCoachTram", DataFormat.Json);
            var response = client.Execute<BusStopCodeResponse>(request).Data.StopPoints;

            List<StopPoint> sorted = response.OrderBy(b => b.distance).ToList();
            var nSorted = sorted.Take(nStops);
            
            foreach (var b in nSorted)
            {
                 //Console.WriteLine(b.naptanId);
                 busStopCodes.Add(b.naptanId);
            }
            return busStopCodes;
        }
    }
}


