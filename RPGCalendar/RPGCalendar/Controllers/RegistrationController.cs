using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RPGCalendar.Controllers
{
    using System.Security.Claims;
    using Core.Dto;
    using Core.Extensions;
    using Core.Services;
    using Identity;
    using Microsoft.AspNetCore.Authorization;
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;


        public RegistrationController(IAuthenticationService authenticationService,
                                      IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> Post(RegistrationModel model)
        {
            var result = await _authenticationService.Register(model);
            if (result is null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var user = await _userService.InsertAsync(new UserInput
            {
                Username = model.Username!,
                Email = model.Email!,
                AuthId = result
            });
            return Ok(user);

        }

    }
}