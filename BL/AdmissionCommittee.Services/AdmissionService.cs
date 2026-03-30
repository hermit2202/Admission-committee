using AdmissionCommittee.Models;
using AdmissionCommittee.Services.Contracts;
using AdmissionCommittee.Storage.Contracts;

namespace AdmissionCommittee.Services
{
    public class AdmissionService : IAdmissionService
    {
        private readonly IStudentStorage _storage;

        public AdmissionService(IStudentStorage storage)
        {
            _storage = storage;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _storage.GetAll();
        }

        public void AddStudent(Student student)
        {
            if (!ValidateStudent(student, out var errorMessage))
            {
                throw new ArgumentException(errorMessage);
            }

            _storage.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            if (!ValidateStudent(student, out var errorMessage))
            {
                throw new ArgumentException(errorMessage);
            }

            _storage.Update(student);
        }

        public void DeleteStudent(string id)
        {
            _storage.Delete(id);
        }

        public string GetStatistics()
        {
            int totalCount = _storage.GetTotalCount();

            if (totalCount == 0)
            {
                return "Нет данных";
            }

            int passedCount = _storage.GetPassedCount(150);
            double averageScore = _storage.GetAverageScore();
            int maxScore = _storage.GetAll().Max(s => s.TotalScore);
            int minScore = _storage.GetAll().Min(s => s.TotalScore);

            return $"Всего: {totalCount} | " +
                   $"> 150 баллов: {passedCount} | " +
                   $"Средний: {averageScore:F1} | " +
                   $"Худший: {minScore} | " +
                   $"Лучший: {maxScore}";
        }

        public bool ValidateStudent(Student student, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(student.FullName))
            {
                errorMessage = "ФИО обязательно для заполнения";
                return false;
            }

            if (student.FullName.Trim().Length < 3)
            {
                errorMessage = "ФИО должно содержать минимум 3 символа";
                return false;
            }

            if (student.MathScores < 0 || student.MathScores > 100)
            {
                errorMessage = "Балл по математике должен быть от 0 до 100";
                return false;
            }

            if (student.RusScores < 0 || student.RusScores > 100)
            {
                errorMessage = "Балл по русскому языку должен быть от 0 до 100";
                return false;
            }

            if (student.ComputerScienceScores < 0 || student.ComputerScienceScores > 100)
            {
                errorMessage = "Балл по информатике должен быть от 0 до 100";
                return false;
            }

            if (student.DateBirth > DateTime.Now)
            {
                errorMessage = "Дата рождения не может быть в будущем";
                return false;
            }

            int age = DateTime.Now.Year - student.DateBirth.Year;
            if (student.DateBirth.Date > DateTime.Now.AddYears(-age))
            {
                age--;
            }

            if (age < 10 || age > 100)
            {
                errorMessage = $"Возраст должен быть от 10 до 100 лет (сейчас: {age})";
                return false;
            }

            return true;
        }
    }
}