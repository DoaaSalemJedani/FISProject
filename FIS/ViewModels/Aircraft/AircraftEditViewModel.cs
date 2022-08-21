using System.ComponentModel.DataAnnotations;

namespace FIS.ViewModels
{
    public class AircraftEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public string Registration { get; set; }
        [Required]
        public string Type { get; set; }
        [Display(Name = "Y Config")]
        public int YConfig { get; set; }
        [Display(Name = "J Config")]
        public int JConfig { get; set; }
        [Display(Name = "F Config")]
        public int FConfig { get; set; }
    }
}
