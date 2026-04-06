using AdmissionCommittee.Models;
using AdmissionCommittee.Storage.Contracts;

namespace AdmissionCommittee.Storage.InMemory
{

    /// <summary>
    /// Реализация хранилища абитуриентов в памяти.
    /// </summary>
    /// <remarks>
    /// Использует <see cref="Dictionary{TKey,TValue}"/> для хранения данных.
    /// Данные не сохраняются между запусками приложения.
    /// </remarks>
    /// <seealso cref="IStudentStorage"/>
    public class InMemoryStudentStorage : IStudentStorage
    {
        private readonly Dictionary<string, Student> students;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="InMemoryStudentStorage"/>
        /// и заполняет хранилище тестовыми данными.
        /// </summary>
        public InMemoryStudentStorage()
        {
            students = new Dictionary<string, Student>();
            InitializeTestData();
        }

        private void InitializeTestData()
        {
            Add(new Student
            {
                FullName = "Артемьев Анатолий Андреевич",
                Gender = Gender.Male,
                DateBirth = new DateTime(2000, 8, 12),
                FormOfEducation = "Очное",
                MathScores = 90,
                RusScores = 70,
                ComputerScienceScores = 100,
            });

            Add(new Student
            {
                FullName = "Петрова Анастасия Борисовна",
                Gender = Gender.Female,
                DateBirth = new DateTime(1998, 10, 25),
                FormOfEducation = "Очное-заочное",
                MathScores = 70,
                RusScores = 50,
                ComputerScienceScores = 60,
            });

            Add(new Student
            {
                FullName = "Сидоров Александр Фёдорович",
                Gender = Gender.Male,
                DateBirth = new DateTime(2003, 2, 10),
                FormOfEducation = "Заочное",
                MathScores = 80,
                RusScores = 90,
                ComputerScienceScores = 95,
            });
        }

        /// <inheritdoc/>
        public IEnumerable<Student> GetAll() => students.Values.ToList();

        /// <inheritdoc/>
        public Student? GetById(string id)
        {
            students.TryGetValue(id, out var student);
            return student;
        }

        /// <inheritdoc/>
        /// <remarks>
        /// Использует <see cref="Student.Id"/> как ключ в словаре.
        /// Не генерирует ID — ожидает, что он уже установлен в объекте.
        /// </remarks>
        public void Add(Student student)
        {
            students.Add(student.Id, student);
        }

        /// <inheritdoc/>
        /// <remarks>
        /// Поиск записи осуществляется по <see cref="Student.Id"/>.
        /// Если запись не найдена, бросается <see cref="KeyNotFoundException"/>.
        /// </remarks>
        public void Update(Student student)
        {
            var existing = GetById(student.Id);

            if (existing == null)
            {
                throw new KeyNotFoundException($"Студент с ID {student.Id} не найден");
            }

            students[student.Id] = student;
        }

        /// <inheritdoc/>
        public void Delete(string id) => students.Remove(id);

        /// <inheritdoc/>
        public int GetTotalCount() => students.Count;

        /// <inheritdoc/>
        public int GetPassedCount(int threshold = ValidationConstants.PassThreshold)
            => students.Count(s => s.Value.TotalScore > threshold);

        /// <inheritdoc/>
        public double GetAverageScore()
            => students.Any() ? students.Average(s => s.Value.TotalScore) : 0;
    }
}
