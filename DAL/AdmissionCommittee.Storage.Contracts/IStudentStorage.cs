using AdmissionCommittee.Models;

namespace AdmissionCommittee.Storage.Contracts
{
    public interface IStudentStorage
    {
        IEnumerable<Student> GetAll();

        Student? GetById(string id);

        void Add(Student student);

        void Update(Student student);

        void Delete(string id);

        int GetTotalCount();

        int GetPassedCount(int threshold = 150);

        double GetAverageScore();
    }
}
