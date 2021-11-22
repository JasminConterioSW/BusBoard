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
            
            string busStopCode = Comms.PromptUserChoice();

            var tflApi = new TflApi();
            List<string> nextBuses = tflApi.GetBusTimes(busStopCode, 5);

            var postcodeApi = new PostCodeApi();
            var postCode = postcodeApi.GetLongLatFromPostCodeApi("SW1A 1AA");
            
            Console.Write($"{postCode.Latitude}");
        }
    }
}