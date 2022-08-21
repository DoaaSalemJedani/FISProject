using System;

namespace FIS.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime FlightDate { get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public Aircraft Aircraft { get; set; }
        public int YPassengers { get; set; }
        public int JPassengers { get; set; }
        public int FPassengers { get; set; }
    }
}
