using Microsoft.AspNetCore.Mvc;

namespace SecretMadonna.TestPrj.MvcUI.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
