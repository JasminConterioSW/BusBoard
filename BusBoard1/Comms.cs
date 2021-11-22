using System;

namespace BusBoard1
{
    public class Comms
    {
        public static string PromptUserChoice()
        {
            Console.WriteLine("Please input a Postcode");
  //              var choice = Console.ReadLine();
                var choice = "SW1A1AA";
                Console.WriteLine(choice);
                return choice;
        }
    }
}