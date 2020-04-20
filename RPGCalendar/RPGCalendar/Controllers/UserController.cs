
namespace RPGCalendar.Controllers
{
    using Core.Dto;
    using Core.Services;
    using Microsoft.AspNetCore.Mvc;
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController<User, UserInput>
    {
        public UserController(IUserService service) 
            : base(service)
        {
        }
    }
}