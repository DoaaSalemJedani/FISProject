using System.Collections.Generic;

namespace FIS.ViewModels
{
    public class FlightListViewModel
    {
        public string Query { get; set; }
        public List<FlightItem> Flights { get; set; }

        public class FlightItem
        {
            public int Id { get; set; }
            public string FlightNumber { get; set; }
            public string FlightDate { get; set; }
            public string DepartureStation { get; set; }
            public string ArrivalStation { get; set; }
        }
    }
}
