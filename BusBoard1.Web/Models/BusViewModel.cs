using BusBoard1.Api.Models;

namespace BusBoard1.Web.Models
{
    public class BusViewModel
    {
        public int TimeToStation { get; set; }
        public string DestinationName { get; set; }
        public string LineName { get; set; }
        public string StationName { get; set; }
        
        
        public BusViewModel(Bus bus)
        {
            TimeToStation = bus.TimeToStation;
            DestinationName = bus.DestinationName;
            LineName = bus.LineName;
            StationName = bus.StationName;
        }
    }
}
