using school_holistic.Models;
using System.ComponentModel.DataAnnotations;

namespace school_holistic.DTOs
{
    public class SubjectGetWithStudent
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
