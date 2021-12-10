using Microsoft.AspNetCore.Mvc;

namespace SecretMadonna.TestPrj.MvcUI.Areas.Admin.Controllers
{
    public class AccountController : AdminBaseController
    {
        /// <summary>
        /// 1.账号密码登录
        /// 2.手机短信验证码登录
        /// 3.扫码登录
        /// 4.第三方登录
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return NoContent();
        }
    }
}
