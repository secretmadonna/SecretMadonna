using Exceptionless;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretMadonna.TestPrj.MvcUI.Models;
using System;
using System.Diagnostics;
using LogLevel = Exceptionless.Logging.LogLevel;

namespace SecretMadonna.TestPrj.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var methodBase = System.Reflection.MethodBase.GetCurrentMethod();
            var message = $"{methodBase.DeclaringType.FullName}.{methodBase.Name}";

            _logger.LogTrace(message);
            _logger.LogDebug(message);
            using (_logger.BeginScope(new Guid().ToString()))
            {
                _logger.LogInformation(message);
                _logger.LogError(message);
                _logger.LogCritical(message);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            var methodBase = System.Reflection.MethodBase.GetCurrentMethod();
            var message = $"{methodBase.DeclaringType.FullName}.{methodBase.Name}";

            _logger.LogTrace(message);
            _logger.LogDebug(message);
            using (_logger.BeginScope(new Guid().ToString()))
            {
                _logger.LogInformation(message);
                _logger.LogError(message);
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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
