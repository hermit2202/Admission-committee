using System.Diagnostics;
using AdmissionCommittee.Models;
using AdmissionCommittee.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace AdmissionCommittee.Services
{
    public class AdmissionServiceLogWrapper : IAdmissionService
    {
        private readonly IAdmissionService mainService;
        private readonly ILogger<AdmissionServiceLogWrapper> logger;

        /// <summary>
        /// Конструктор wrapper для логирования производительности методов класса AdmissionService
        /// </summary>
        /// <param name="mainService">Оригинальный сервис для оборачивания.</param>
        /// <param name="logger">Логгер для записи сообщений</param>
        public AdmissionServiceLogWrapper(IAdmissionService mainService,
            ILogger<AdmissionServiceLogWrapper> logger)
        {
            this.mainService = mainService;
            this.logger = logger;
        }

        /// <summary>
        /// Добавляет студента с логированием производительности.
        /// </summary>
        /// <param name="student">Студент для добавления.</param>
        public void AddStudent(Student student)
        {
            var watch = new Stopwatch();
            watch.Start();

            try
            {
                mainService.AddStudent(student);
            }
            finally
            {
                watch.Stop();

                logger.LogDebug("AdmissionService.AddStudent: {ElapsedMilliseconds} ms.",
                    watch.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Удаляет студента с логированием производительности.
        /// </summary>
        /// <param name="id">Идентификатор студента.</param>
        public void DeleteStudent(string id)
        {
            var watch = new Stopwatch();
            watch.Start();

            try
            {
                mainService.DeleteStudent(id);
            }
            finally
            {
                watch.Stop();

                logger.LogDebug("AdmissionService.DeleteStudent: {ElapsedMilliseconds} ms.",
                    watch.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Возвращает всех студентов с логированием производительности.
        /// </summary>
        /// <returns>Коллекцию студентов.</returns>
        public IEnumerable<Student> GetAllStudents()
        {
            var watch = new Stopwatch();
            watch.Start();

            var count = 0;

            try
            {
                var result = mainService.GetAllStudents();
                var studentsList = result?.ToList() ?? new List<Student>();

                count = studentsList.Count;

                return studentsList;
            }
            finally
            {
                watch.Stop();

                logger.LogDebug(
                    "AdmissionService.GetAllStudents: {ElapsedMilliseconds} ms. Count: {Count}",
                    watch.ElapsedMilliseconds,
                    count);
            }
        }

        /// <summary>
        /// Возвращает статистику о студентах с логированием производительности.
        /// </summary>
        /// <returns>Статистику о студентах.</returns>
        public StudentStatistic GetStatistics()
        {
            var watch = new Stopwatch();
            watch.Start();

            try
            {
                var result = mainService.GetStatistics();
                return result;
            }
            finally
            {
                watch.Stop();

                logger.LogDebug("AdmissionService.GetStatistics: {ElapsedMilliseconds} ms.",
                    watch.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Обновляет студента с логированием производительности.
        /// </summary>
        /// <param name="student">Студент для обновления.</param>
        public void UpdateStudent(Student student)
        {
            var watch = new Stopwatch();
            watch.Start();

            try
            {
                mainService.UpdateStudent(student);
            }
            finally
            {
                watch.Stop();

                logger.LogDebug("AdmissionService.UpdateStudent: {ElapsedMilliseconds} ms.",
                    watch.ElapsedMilliseconds);
            }
        }
    }
}
