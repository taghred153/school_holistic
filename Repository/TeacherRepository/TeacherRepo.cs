using school_holistic.DTOs;
using school_holistic.Models;

namespace school_holistic.Repository.TeacherRepository
{
    public class TeacherRepo : ITeacherRepo
    {
        private readonly AppDbContext _context;

        public TeacherRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Add(TeacherPost teacherPost)
        {
            var sub = _context.Subjects.FirstOrDefault(x => x.Id == teacherPost.SubjectId);
            if (sub != null)
            {
                Teacher teacher = new Teacher
                {
                    Name = teacherPost.Name,
                    Email = teacherPost.Email,
                    Phone = teacherPost.Phone,
                    SubjectId = teacherPost.SubjectId,
                };
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Not Found");
            }
        }
    }
}
