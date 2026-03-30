using AdmissionCommittee.Models;

namespace AdmissionCommittee.Services.Contracts
{
    public interface IAdmissionService
    {
        IEnumerable<Student> GetAllStudents();

        void AddStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(string id);

        string GetStatistics();

        bool ValidateStudent(Student student, out string errorMessage);
    }
}
