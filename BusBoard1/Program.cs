﻿using System;
using System.Collections.Generic;
using RestSharp;

namespace BusBoard1
{
    class Program
    {
        static void Main(string[] args)
        {
            string busStopCode = Comms.PromptUserChoice();
            List<string> nextBusses = TflApi.GetBusTimes(busStopCode, 5);
        }
    }
}