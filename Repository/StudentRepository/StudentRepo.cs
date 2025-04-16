using Microsoft.EntityFrameworkCore;
using school_holistic.DTOs;
using school_holistic.Models;

namespace school_holistic.Repository.StudentRepository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly AppDbContext _context;

        public StudentRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Add(StudentPost studentPost)
        {
            Student student = new Student
            {
                Name = studentPost.Name,
                Email = studentPost.Email,
                Laptop = new Laptop
                {
                    Model = studentPost.laptopGetWithSubject.Model,
                },
                Teachers = studentPost.teacherPostWithStudents.Select(x => new Teacher
                {
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                }).ToList(),
            };
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var res = _context.Students.FirstOrDefault(x => x.Id == id);
            if (res != null)
            {
                _context.Students.Remove(res);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Not Found");
            }
        }

        public List<StudentGet> GetAll()
        {
            var res = _context.Students
                .Include(x => x.Teachers)
                .ThenInclude(x => x.Subject)
                .Include(x => x.Laptop)
                .Select(x => new  StudentGet
                {
                    Name = x.Name,
                    Email = x.Email,
                    teacherGetWithStudents = x.Teachers.Select(x => new TeacherGetWithStudent
                    {
                        Name = x.Name,
                        Email = x.Email,
                        Phone = x.Phone,
                        subjectGetWithStudent = new SubjectGetWithStudent
                        {
                            Name = x.Subject.Name,
                        }
                    }).ToList(),
                    laptopGetWithSubject = new LaptopGetWithSubject
                    {
                        Model = x.Laptop.Model,
                    }
                }).ToList();
            return res;
        }
        public void Update(StudentUpdate studentUpdate, int id)
        {
            var res = _context.Students
                .Include(x => x.Teachers)
                .Include(x => x.Laptop)
                .FirstOrDefault(x => x.Id == id);
            if (res == null)
            {
                throw new Exception("Not Found");
            }

            res.Name = studentUpdate.Name;
            res.Email = studentUpdate.Email;

            foreach (var teach in studentUpdate.teacherUpdates)
            {
                var oldteacher = res.Teachers.FirstOrDefault(x => x.Id == teach.oldId);
                if (oldteacher != null)
                {
                    _context.Teachers.Remove(oldteacher);
                }

                Teacher teacher = new Teacher
                {
                    Email = teach.Email,
                    Name = teach.Name,
                    Phone = teach.Phone,
                    Id = teach.newId,
                };
                res.Teachers.Add(teacher);
            }
            
            if (studentUpdate.laptopGetWithSubject != null)
            {
                res.Laptop.Model = studentUpdate.laptopGetWithSubject.Model;
            }
            _context.SaveChanges();
        }
    }
}
