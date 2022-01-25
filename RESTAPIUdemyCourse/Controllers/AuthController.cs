using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTAPIUdemyCourse.Business;
using RESTAPIUdemyCourse.Data.VO;

namespace RESTAPIUdemyCourse.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserVO user)
        {
            if (user == null) return BadRequest("Invalid Client Request");
            var token = _loginBusiness.ValidateCredentials(user);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVO)
        {
            if (tokenVO == null) return BadRequest("Invalid Client Request");
            var token = _loginBusiness.ValidateCredentials(tokenVO);
            if (token == null) return BadRequest();
            return Ok(token);
        }

        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var userName  = User.Identity.Name;
            var result = _loginBusiness.RevokeToken(userName);
            if (!result) return BadRequest("Invalid Client Request");
            return NoContent();
        }
    }
}
