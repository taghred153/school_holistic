using school_holistic.Models;
using System.ComponentModel.DataAnnotations;

namespace school_holistic.DTOs
{
    public class SubjectGet
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public List<TeacherGetWithSubject> teacherGetWithSubjects { get; set; } = new List<TeacherGetWithSubject>();
    }
}
