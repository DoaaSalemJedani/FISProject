using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FIS.ViewModels
{
    public class FlightEditViewModel
    {
        public int Id { get; set; }

        // step 1
        [Required]
        [RegularExpression("(S|s)(V|v)[0-9]{4}", ErrorMessage = "Invalid")]
        [MinLength(6)]
        [MaxLength(6)]
        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Flight Date")]
        public DateTime FlightDate { get; set; }

        [Required]
        [RegularExpression("([A-Za-z]{3})", ErrorMessage = "Invalid")]
        [MinLength(3)]
        [MaxLength(3)]
        [Display(Name = "Departure Station")]
        public string DepartureStation { get; set; }

        [Required]
        [RegularExpression("([A-Za-z]{3})", ErrorMessage = "Invalid")]
        [MinLength(3)]
        [MaxLength(3)]
        [Display(Name = "Arrival Station")]
        public string ArrivalStation { get; set; }

        [Display(Name = "Y Config")]
        public int YPassengers { get; set; }

        [Display(Name = "J Config")]
        public int JPassengers { get; set; }

        [Display(Name = "F Config")]
        public int FPassengers { get; set; }


        // step 2
        public string Aircraft { get; set; }
        public List<SelectListItem> AircraftList { get; set; }
    }
}
