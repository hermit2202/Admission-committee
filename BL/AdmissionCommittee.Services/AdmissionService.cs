using System.ComponentModel.DataAnnotations;
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
            ValidateStudent(student);
            storage.Add(student);
        }

        /// <inheritdoc/>
        /// <remarks>
        /// Перед обновлением вызывает <see cref="ValidateStudent"/>.
        /// Бросает <see cref="KeyNotFoundException"/>, если студент с таким ID не найден.
        /// </remarks>
        public void UpdateStudent(Student student)
        {
            ValidateStudent(student);

            try
            {
                storage.Update(student);
            }
            catch (KeyNotFoundException)
            {
                throw new InvalidOperationException(
                    $"Не удалось обновить студента: запись с Id={student.Id} не найдена.",
                    null);
            }
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

        private void ValidateStudent(Student student)
        {
            var context = new ValidationContext(student);
            var results = new List<ValidationResult>();

            ValidateAge(student);

            if (!Validator.TryValidateObject(student, context, results, validateAllProperties: true))
            {
                var errors = string.Join("; ", results.Select(r => r.ErrorMessage));
                throw new ArgumentException(errors);
            }
        }

        private void ValidateAge(Student student)
        {
            if (student.DateBirth > DateTime.Now)
            {
                throw new ArgumentException("Дата рождения не может быть в будущем");
            }

            var age = DateTime.Now.Year - student.DateBirth.Year;
            if (student.DateBirth.Date > DateTime.Now.AddYears(-age))
            {
                age--;
            }

            if (age < ValidationConstants.MinAge || age > ValidationConstants.MaxAge)
            {
                throw new ArgumentException(
                    $"Возраст должен быть от {ValidationConstants.MinAge} до " +
                    $"{ValidationConstants.MaxAge} лет (сейчас: {age})");
            }
        }
    }
}
