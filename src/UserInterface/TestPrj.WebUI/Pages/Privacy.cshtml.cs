using Exceptionless;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using LogLevel = Exceptionless.Logging.LogLevel;

namespace SecretMadonna.TestPrj.WebUI.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var methodBase = System.Reflection.MethodBase.GetCurrentMethod();
            var message = $"{methodBase.DeclaringType.FullName}.{methodBase.Name}";

            _logger.LogTrace(message);
            _logger.LogDebug(message);
            _logger.LogError(message);
            using (_logger.BeginScope(new Guid().ToString()))
            {
                _logger.LogInformation(message);
                _logger.LogCritical(message);
            }

            ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Other).Submit();
            ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Trace).Submit();
            ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Debug).Submit();
            ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Info).Submit();
            ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Warn).Submit();
            ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Error).Submit();
            ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Fatal).Submit();
            ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Off).Submit();
        }
    }
}
