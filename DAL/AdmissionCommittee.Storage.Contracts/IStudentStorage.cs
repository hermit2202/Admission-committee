using AdmissionCommittee.Models;

namespace AdmissionCommittee.Storage.Contracts
{

    /// <summary>
    /// Контракт хранилища данных абитуриентов.
    /// Определяет операции доступа к данным (CRUD) и методы получения статистики.
    /// </summary>
    /// <remarks>
    /// Интерфейс реализует паттерн <c>Repository</c> для абстракции слоя хранения данных.
    /// Позволяет заменять реализацию хранилища без изменения бизнес-логики:
    /// <list type="bullet">
    /// <item><see cref="InMemory.InMemoryStudentStorage"/> — хранение в памяти (для тестов и демо)</item>
    /// <item>Возможна реализация для базы данных, файла или веб-сервиса</item>
    /// </list>
    /// </remarks>
    /// <seealso cref="Services.AdmissionService"/>
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