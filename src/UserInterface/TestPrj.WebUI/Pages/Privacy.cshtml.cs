using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

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
            _logger.LogInformation($"{methodBase.DeclaringType.FullName}.{methodBase.Name}");
        }
    }
}
