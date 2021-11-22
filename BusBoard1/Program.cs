using System;
using System.Collections.Generic;
using RestSharp;

namespace BusBoard1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bus stop code: 490008660N
            
            string postcode = Comms.PromptUserChoice();
            
            var postcodeApi = new PostCodeApi();
            var longLatObject = postcodeApi.GetLongLatFromPostCodeApi(postcode);
            

            string buStopCode = "490008660N";

            var tflApi = new TflApi();
            List<string> busStopCodes = tflApi.GetBusStopCodesFromLongLat(longLatObject, 2);

            foreach (var busStopCode in busStopCodes)
            {
                List<string> nextBuses = tflApi.GetBusTimes(busStopCode, 5);
            }
            
            
            Console.Write($"{longLatObject.Latitude}");
        }
    }
}