using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretMadonna.TestPrj.Application.Abstractions.Dtos;
using SecretMadonna.TestPrj.MvcUI.Dtos;
using System.Collections.Generic;

namespace SecretMadonna.TestPrj.MvcUI.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost, ActionName("Index")]
        public IActionResult PostIndex()
        {
            var obj = new ResponseDto<PageDto<List<UserDto>>>()
            {
                ret = "200",
                msg = "OK",
                data = new PageDto<List<UserDto>>
                {
                    CurrentPageIndex = 1,
                    PrePageRecordCount = 10,
                    TotalRecordCount = 1,
                    CurrentPageData = new List<UserDto>() { new UserDto() { UserId = 1, UserLoginName = "test", UserName = "测试" } }
                }
            };
            return new ObjectResult(obj);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            base.Dispose(disposing);
        }
    }
}
