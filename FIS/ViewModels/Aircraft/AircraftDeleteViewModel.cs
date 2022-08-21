using System.ComponentModel.DataAnnotations;

namespace FIS.ViewModels
{
    public class AircraftDeleteViewModel
    {
        public int Id { get; set; }
        public string Registration { get; set; }
        public string Type { get; set; }
        [Display(Name = "Y Config")]
        public int YConfig { get; set; }
        [Display(Name = "J Config")]
        public int JConfig { get; set; }
        [Display(Name = "F Config")]
        public int FConfig { get; set; }
    }
}
