using school_holistic.DTOs;

namespace school_holistic.Repository.StudentRepository
{
    public interface IStudentRepo
    {
        public void Add(StudentPost studentPost);
        public List<StudentGet> GetAll();
        public void Delete(int id);
        public void Update(StudentUpdate studentUpdate, int id);
    }
}
