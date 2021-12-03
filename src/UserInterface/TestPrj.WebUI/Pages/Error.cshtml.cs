using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace SecretMadonna.TestPrj.WebUI.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var methodBase = System.Reflection.MethodBase.GetCurrentMethod();
            _logger.LogInformation($"{methodBase.DeclaringType.FullName}.{methodBase.Name}");
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
