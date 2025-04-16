using school_holistic.Models;
using System.ComponentModel.DataAnnotations;

namespace school_holistic.DTOs
{
    public class SubjectPost
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public List<TeacherPostWithSubject> teacherPostWithSubjects { get; set; } = new List<TeacherPostWithSubject>();
    }
}
