using school_holistic.Models;
using System.ComponentModel.DataAnnotations;

namespace school_holistic.DTOs
{
    public class LaptopGetWithSubject
    {
        [Required, MaxLength(100)]
        public string Model { get; set; }
    }
}
