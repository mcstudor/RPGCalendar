
namespace RPGCalendar.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Core.Dto;
    using Core.Extensions;
    using Core.Services;
    using Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly ISession _session;


        public LoginController(IHttpContextAccessor httpContextAccessor,
            IAuthenticationService authenticationService,
            IUserService userService)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> Login(LoginModel model)
        {
            var result = await _authenticationService.Login(model);
            if (result is null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var user = _userService.GetUserByAuthId(result);
            _session.Set("User", user);
            return Ok(user);

        }


    }
}