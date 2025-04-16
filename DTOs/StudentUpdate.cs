using school_holistic.Models;
using System.ComponentModel.DataAnnotations;

namespace school_holistic.DTOs
{
    public class StudentUpdate
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public List<TeacherUpdate> teacherUpdates { get; set; } = new List<TeacherUpdate>();
        public LaptopGetWithSubject ?laptopGetWithSubject { get; set; }
    }
}
