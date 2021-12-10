using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretMadonna.TestPrj.Application.Abstractions.Dtos;
using SecretMadonna.TestPrj.MvcUI.Dtos;
using SecretMadonna.TestPrj.MvcUI.Vos;

namespace SecretMadonna.TestPrj.MvcUI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 注册：
        /// 用户名、密码、手机号、手机短信验证码（注册的手机短信验证码）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register(RegisterVo vo)
        {
            return View(vo);
        }
        [HttpPost, ActionName("Register")]
        public IActionResult PostRegister(RegisterVo vo)
        {
            var obj = new ResponseDto<UserDto>()
            {
                ret = "200",
                msg = "OK",
                data = new UserDto() { UserId = 1, UserLoginName = "test", Mobile = "18888888888", PassWord = "test", UserName = null }
            };
            return new ObjectResult(obj);
        }

        /// <summary>
        /// 登录：
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
        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout(string retUrl)
        {
            if (!string.IsNullOrWhiteSpace(retUrl) && Url.IsLocalUrl(retUrl))
            {
                return LocalRedirect(retUrl);
            }
            return LocalRedirect("~/");
        }
    }
}
