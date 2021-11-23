using System;

namespace BusBoard1
{
    public class Comms
    {
        public static string PromptUserChoice()
        {
            Console.WriteLine("Please input a Postcode");
             var choice = Console.ReadLine();
                //var choice = "NW51TL";
                //Console.WriteLine(choice);
                return choice;
        }
    }
}