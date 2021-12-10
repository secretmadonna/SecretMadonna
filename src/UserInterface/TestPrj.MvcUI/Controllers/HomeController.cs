using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretMadonna.TestPrj.MvcUI.Vos;
using System;
using System.Diagnostics;

namespace SecretMadonna.TestPrj.MvcUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var methodBase = System.Reflection.MethodBase.GetCurrentMethod();
            //var message = $"{methodBase.DeclaringType.FullName}.{methodBase.Name}";
            var message = "message";

            _logger.LogTrace(new EventId(0, "default"), message);
            _logger.LogDebug(new EventId(0, "default"), message);
            using (_logger.BeginScope(Guid.NewGuid()))
            {
                _logger.LogInformation(new EventId(0, "default"), message);
                _logger.LogError(new EventId(0, "default"), message);
                _logger.LogCritical(new EventId(0, "default"), message);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            //var methodBase = System.Reflection.MethodBase.GetCurrentMethod();
            //var message = $"{methodBase.DeclaringType.FullName}.{methodBase.Name}";

            //_logger.LogTrace(message);
            //_logger.LogDebug(message);
            //using (_logger.BeginScope(new Guid().ToString()))
            //{
            //    _logger.LogInformation(message);
            //    _logger.LogError(message);
            //    _logger.LogCritical(message);
            //}

            //ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Other).Submit();
            //ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Trace).Submit();
            //ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Debug).Submit();
            //ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Info).Submit();
            //ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Warn).Submit();
            //ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Error).Submit();
            //ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Fatal).Submit();
            //ExceptionlessClient.Default.CreateLog(methodBase.DeclaringType.Name, message, LogLevel.Off).Submit();

            var a = 0;
            var b = a / a;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            //if (exceptionHandlerPathFeature != null)
            //{
            //    _logger.LogError(exceptionHandlerPathFeature.Error, exceptionHandlerPathFeature.Path);
            //}
            return View(new ErrorVo { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">StatusCode</param>
        /// <returns></returns>
        public IActionResult StatusCode(string id)
        {
            return View(model: id);
        }
    }
}
