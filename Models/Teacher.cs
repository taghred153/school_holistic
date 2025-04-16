using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace school_holistic.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Phone {  get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public int ?SubjectId { get; set; }
        public Subject ?Subject { get; set; } 
    }
}
