using System.ComponentModel.DataAnnotations;

namespace school_holistic.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public int ?LaptopId { get; set; }
        public Laptop ?Laptop { get; set; } 
    }
}
