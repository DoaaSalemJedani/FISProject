using System;
using System.ComponentModel.DataAnnotations;

namespace FIS.ViewModels
{
    public class FlightDeleteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Flight Date")]
        public DateTime FlightDate { get; set; }

        [Display(Name = "Departure Station")]
        public string DepartureStation { get; set; }

        [Display(Name = "Arrival Station")]
        public string ArrivalStation { get; set; }

        [Display(Name = "Y Config")]
        public int YPassengers { get; set; }

        [Display(Name = "J Config")]
        public int JPassengers { get; set; }

        [Display(Name = "F Config")]
        public int FPassengers { get; set; }

        public string Aircraft { get; set; }
    }
}
