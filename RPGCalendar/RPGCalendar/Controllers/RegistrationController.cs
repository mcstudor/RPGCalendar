using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RPGCalendar.Controllers
{
    using Identity;
    using Microsoft.AspNetCore.Authorization;
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public RegistrationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(RegistrationModel model)
        {
            var result = await _authenticationService.Register(model);
            return result
                ? StatusCode(StatusCodes.Status201Created)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

    }
}