using AdmissionCommittee.Models;
using AdmissionCommittee.Services.Contracts;
using AdmissionCommittee.Storage.Contracts;

namespace AdmissionCommittee.Services
{
    /// <summary>
    /// Сервис управления приёмной комиссией.
    /// Реализует бизнес-логику для работы с абитуриентами.
    /// </summary>
    /// <remarks>
    /// Класс реализует интерфейс <see cref="IAdmissionService"/>
    /// и использует хранилище <see cref="IStudentStorage"/> для доступа к данным.
    /// Все операции проходят валидацию через <see cref="ValidateStudent"/>.
    /// </remarks>
    public class AdmissionService : IAdmissionService
    {
        private readonly IStudentStorage storage;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="AdmissionService"/>.
        /// </summary>
        /// <param name="storage">
        /// Хранилище данных, реализующее <see cref="IStudentStorage"/>.
        /// </param>
        public AdmissionService(IStudentStorage storage)
        {
            this.storage = storage;
        }

        /// <inheritdoc/>
        public IEnumerable<Student> GetAllStudents()
        {
            return storage.GetAll();
        }

        /// <inheritdoc/>
        /// <remarks>
        /// Перед добавлением вызывает <see cref="ValidateStudent"/>.
        /// При ошибке валидации бросает <see cref="ArgumentException"/>.
        /// </remarks>
        public void AddStudent(Student student)
        {
            if (!ValidateStudent(student, out var errorMessage))
            {
                throw new ArgumentException(errorMessage);
            }

            storage.Add(student);
        }

        /// <inheritdoc/>
        /// <remarks>
        /// Перед обновлением вызывает <see cref="ValidateStudent"/>.
        /// Бросает <see cref="KeyNotFoundException"/>, если студент с таким ID не найден.
        /// </remarks>
        public void UpdateStudent(Student student)
        {
            if (!ValidateStudent(student, out var errorMessage))
            {
                throw new ArgumentException(errorMessage);
            }

            storage.Update(student);
        }

        /// <inheritdoc/>
        public void DeleteStudent(string id)
        {
            storage.Delete(id);
        }

        /// <inheritdoc/>
        /// <remarks>
        /// Формат строки: <c>"Всего: {n} | > 150 баллов: {m} | Средний: {avg} | Худший: {min} | Лучший: {max}"</c>
        /// Пороговое значение (150 баллов) жёстко задано.
        /// </remarks>
        public StudentStatistic GetStatistics()
        {
            int totalCount = storage.GetTotalCount();
            if (totalCount == 0)
            {
                return StudentStatistic.Empty;
            }

            return new StudentStatistic
            {
                TotalCount = totalCount,
                PassedCount = storage.GetPassedCount(150),
                AverageScore = storage.GetAverageScore(),
                MaxScore = storage.GetAll().Max(s => s.TotalScore),
                MinScore = storage.GetAll().Min(s => s.TotalScore),
                Threshold = ValidationConstants.PassThreshold,
            };
        }

        /// <inheritdoc/>
        /// <remarks>
        /// Проверяемые правила:
        /// <list type="bullet">
        /// <item>ФИО: не пустое, минимум 3 символа</item>
        /// <item>Дата рождения: не в будущем, возраст 10–100 лет</item>
        /// <item>Баллы ЕГЭ: диапазон 0–100 для каждого предмета</item>
        /// </list>
        /// Метод не бросает исключения — возвращает результат через <paramref name="errorMessage"/>.
        /// </remarks>
        public bool ValidateStudent(Student student, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(student.FullName))
            {
                errorMessage = "ФИО обязательно для заполнения";
                return false;
            }

            if (student.FullName.Trim().Length < ValidationConstants.MinFullNameLength)
            {
                errorMessage = "ФИО должно содержать минимум 3 символа";
                return false;
            }

            if (student.MathScores < ValidationConstants.MinScore
                || student.MathScores > ValidationConstants.MaxScore)
            {
                errorMessage = "Балл по математике должен быть от 0 до 100";
                return false;
            }

            if (student.RusScores < ValidationConstants.MinScore
                || student.RusScores > ValidationConstants.MaxScore)
            {
                errorMessage = "Балл по русскому языку должен быть от 0 до 100";
                return false;
            }

            if (student.ComputerScienceScores < ValidationConstants.MinScore
                || student.ComputerScienceScores > ValidationConstants.MaxScore)
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

            if (age < ValidationConstants.MinAge || age > ValidationConstants.MaxAge)
            {
                errorMessage = $"Возраст должен быть от 10 до 100 лет (сейчас: {age})";
                return false;
            }

            return true;
        }
    }
}
