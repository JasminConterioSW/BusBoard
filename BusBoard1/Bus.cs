namespace BusBoard1
{
    public class Bus
    {
        public int timeToStation { get; set; }
        public string destinationName { get; set; }
        public string lineName { get; set; } //linename
        
        public Bus(int timeToStation, string destinationName, string lineName)
        {
            timeToStation = timeToStation;
            destinationName = destinationName;
            lineName = lineName;
        }
    }
}