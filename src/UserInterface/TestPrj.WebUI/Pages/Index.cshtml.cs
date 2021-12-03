using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

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
            var methodBase = System.Reflection.MethodBase.GetCurrentMethod();
            _logger.LogInformation($"{methodBase.DeclaringType.FullName}.{methodBase.Name}");
        }
    }
}
