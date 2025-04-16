using school_holistic.DTOs;

namespace school_holistic.Repository.SubjectRepository
{
    public interface ISubjectRepo
    {
        public void Add(SubjectPost subjectPost);
        public SubjectGet GetById(int id);
    }
}
