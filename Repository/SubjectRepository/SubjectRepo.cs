using Microsoft.EntityFrameworkCore;
using school_holistic.DTOs;
using school_holistic.Models;

namespace school_holistic.Repository.SubjectRepository
{
    public class SubjectRepo : ISubjectRepo
    {
        private readonly AppDbContext _context;

        public SubjectRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Add(SubjectPost subjectPost)
        {
            Subject subject = new Subject
            {
                Name = subjectPost.Name,
                teachers = subjectPost.teacherPostWithSubjects.Select(x => new Teacher
                {
                    Name = x.Name,
                    Phone = x.Phone,
                    Email = x.Email,
                    Students = x.studentPostWithSubjects.Select(s => new Student
                    {
                        Name = s.Name,
                        Email = s.Email,
                        Laptop = new Laptop
                        {
                            Model = s.LaptopGetWithSubject.Model,
                        }
                    }).ToList(),
                }).ToList(),
            };
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        public SubjectGet GetById(int id)
        {
            var res = _context.Subjects
                .Include(x => x.teachers)
                .ThenInclude(x => x.Students)
                .ThenInclude(x => x.Laptop)
                .FirstOrDefault(x => x.Id == id);
            if (res != null)
            {
                return new SubjectGet
                {
                    Name = res.Name,
                    teacherGetWithSubjects = res.teachers.Select(x => new TeacherGetWithSubject
                    {
                        Name = x.Name,
                        Phone = x.Phone,
                        Email = x.Email,
                        studentGetWithSubjects = x.Students.Select(x => new StudentGetWithSubject
                        {
                            Name = x.Name,
                            Email = x.Email,
                            laptopGetWithSubject = new LaptopGetWithSubject
                            {
                                Model = x.Laptop.Model,
                            }
                        }).ToList(),
                    }).ToList(),
                };
            }
            else
            {
                throw new Exception("Not Found");
            }

        }
    }
}