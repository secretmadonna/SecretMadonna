using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace SecretMadonna.TestPrj.WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
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
        }
    }
}
