using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApp.Business;
using RestApp.Data.VO;
using RestApp.Model;

namespace RestApp.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LoginController : Controller
    {
        private ILoginBusiness LoginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            LoginBusiness = loginBusiness;
        }

        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody]UserVO user)
        {
            if (user == null) return BadRequest();
            return LoginBusiness.FindByLogin(user);
        }


    }
}
