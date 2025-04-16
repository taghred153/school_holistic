using school_holistic.Models;
using System.ComponentModel.DataAnnotations;

namespace school_holistic.DTOs
{
    public class StudentGet
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public List<TeacherGetWithStudent> teacherGetWithStudents { get; set; } = new List<TeacherGetWithStudent>();
        public LaptopGetWithSubject ?laptopGetWithSubject { get; set; }
    }
}
