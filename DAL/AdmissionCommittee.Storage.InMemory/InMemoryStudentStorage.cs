using AdmissionCommittee.Models;
using AdmissionCommittee.Storage.Contracts;

namespace AdmissionCommittee.Storage.InMemory
{
    public class InMemoryStudentStorage : IStudentStorage
    {
        private readonly Dictionary<string, Student> students;
        private int nextId;

        public InMemoryStudentStorage()
        {
            students = new Dictionary<string, Student>();
            nextId = 1;
            InitializeTestData();
        }

        private void InitializeTestData()
        {
            Add(new Student
            {
                FullName = "Артемьев Анатолий Андреевич",
                Gender = "М",
                DateBirth = new DateTime(2000, 8, 12),
                FormOfEducation = "Очное",
                MathScores = 90,
                RusScores = 70,
                ComputerScienceScores = 100,
            });

            Add(new Student
            {
                FullName = "Петрова Анастасия Борисовна",
                Gender = "Ж",
                DateBirth = new DateTime(1998, 10, 25),
                FormOfEducation = "Очное-заочное",
                MathScores = 70,
                RusScores = 50,
                ComputerScienceScores = 60,
            });

            Add(new Student
            {
                FullName = "Сидоров Александр Фёдорович",
                Gender = "М",
                DateBirth = new DateTime(2003, 2, 10),
                FormOfEducation = "Заочное",
                MathScores = 80,
                RusScores = 90,
                ComputerScienceScores = 95,
            });
        }

        public IEnumerable<Student> GetAll() => students.Values.ToList();

        public Student? GetById(string id)
        {
            students.TryGetValue(id, out var student);
            return student;
        }

        public void Add(Student student)
        {
            var Id = GenerateId();
            students.Add(Id, student);
        }

        public void Update(Student student)
        {
            if (!string.IsNullOrEmpty(student.Id) && students.ContainsKey(student.Id))
            {
                students[student.Id] = student;
            }
            else
            {
                var existing = students.FirstOrDefault(x =>
                    x.Value.FullName == student.FullName &&
                    x.Value.DateBirth == student.DateBirth);

                if (existing.Key != null)
                {
                    students[existing.Key] = student;
                }
                else
                {
                    throw new KeyNotFoundException($"Студент не найден");
                }
            }
        }
        
        public void Delete(string id) => students.Remove(id);

        public int GetTotalCount() => students.Count;

        public int GetPassedCount(int threshold = 150)
            => students.Count(s => s.Value.TotalScore > threshold);

        public double GetAverageScore()
            => students.Any() ? students.Average(s => s.Value.TotalScore) : 0;

        private string GenerateId() => (nextId++).ToString();
    }
}
