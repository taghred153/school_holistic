using System.ComponentModel.DataAnnotations;

namespace school_holistic.DTOs
{
    public class TeacherGetWithSubject
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<StudentGetWithSubject> studentGetWithSubjects { get; set; } = new List<StudentGetWithSubject>();
    }
}
