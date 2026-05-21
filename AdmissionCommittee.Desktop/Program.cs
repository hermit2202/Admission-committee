using AdmissionCommittee.Services;
using AdmissionCommittee.Services.Contracts;
using AdmissionCommittee.Storage.Contracts;
using AdmissionCommittee.Storage.InMemory;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;
using Serilog;

namespace AdmissionCommittee.Desktop
{
    /// <summary>
    /// Точка входа в приложение.
    /// </summary>
    internal static class Program
    {

        /// <summary>
        /// Главная точка входа в приложение.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var seqApiKey = "hB54OWrNfbDdgrrVdgIv";

            Serilog.Log.Logger = new Serilog.LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Seq(
                    serverUrl: "http://localhost:5341",
                    apiKey: seqApiKey,
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug
                )
                .WriteTo.File("logs/log-.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });

            var logger = loggerFactory.CreateLogger<AdmissionServiceLogWrapper>();

            ApplicationConfiguration.Initialize();

            IStudentStorage storage = new InMemoryStudentStorage();
            var originalService = new AdmissionService(storage);
            IAdmissionService service = new AdmissionServiceLogWrapper(
                originalService,
                logger
            );

            Application.Run(new AdmissionCommitteeForm(service));

            loggerFactory.Dispose();
            Serilog.Log.CloseAndFlush();
        }
    }
}
