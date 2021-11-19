using System;

namespace BusBoard1
{
    public class Comms
    {
        public static string PromptUserChoice()
        {
            Console.WriteLine("Please input a postcode");
                var choice = Console.ReadLine();
                // var choice = "490008660N";
                Console.WriteLine(choice);
                return choice;
        }
    }
}