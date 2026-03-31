using AdmissionCommittee.Models;

namespace AdmissionCommittee.Services.Contracts
{

    /// <summary>
    /// Контракт сервиса управления приёмной комиссией.
    /// Определяет операции бизнес-логики для работы с реестром абитуриентов.
    /// </summary>
    /// <remarks>
    /// Интерфейс используется для разделения слоёв приложения:
    /// <list type="bullet">
    /// <item><see cref="AdmissionCommittee.Desktop.AdmissionCommitteeForm"/> (UI) зависит только от этого контракта</item>
    /// <item><see cref="AdmissionCommittee.Services.AdmissionService"/> реализует бизнес-правила</item>
    /// <item>Позволяет подменять реализацию для тестирования (Mock/DI)</item>
    /// </list>
    /// </remarks>
    /// <seealso cref="AdmissionCommittee.Services.AdmissionService"/>
    /// <seealso cref="IStudentStorage"/>
    public interface IAdmissionService
    {
        IEnumerable<Student> GetAllStudents();

        void AddStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(string id);

        StudentStatistic GetStatistics();

        bool ValidateStudent(Student student, out string errorMessage);
    }
}
