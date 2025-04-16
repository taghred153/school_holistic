using System.ComponentModel.DataAnnotations;

namespace school_holistic.Models
{
    public class Laptop
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Model { get; set; }
        public Student ?Student { get; set; } 
    }
}
