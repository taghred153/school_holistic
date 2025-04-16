using school_holistic.Models;
using System.ComponentModel.DataAnnotations;

namespace school_holistic.DTOs
{
    public class StudentPost
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public List<TeacherPostWithStudent> teacherPostWithStudents { get; set; } = new List<TeacherPostWithStudent>();
        public LaptopGetWithSubject ?laptopGetWithSubject { get; set; }
    }
}
