using AdmissionCommittee.Services;
using AdmissionCommittee.Services.Contracts;
using AdmissionCommittee.Storage.Contracts;
using AdmissionCommittee.Storage.InMemory;

namespace AdmissionCommittee.Desktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Создаём зависимости вручную (простой DI)
            IStudentStorage storage = new InMemoryStudentStorage();
            IAdmissionService service = new AdmissionService(storage);

            // Запускаем форму, передавая сервис
            Application.Run(new AdmissionCommitteeForm(service));
        }
    }
}
