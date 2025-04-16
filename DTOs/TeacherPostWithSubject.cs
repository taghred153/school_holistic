using school_holistic.Models;
using System.ComponentModel.DataAnnotations;

namespace school_holistic.DTOs
{
    public class TeacherPostWithSubject
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<StudentPostWithSubject> studentPostWithSubjects { get; set; } = new List<StudentPostWithSubject>();
    }
}
