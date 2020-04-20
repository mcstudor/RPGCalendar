namespace RPGCalendar.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Core.Services;
    using Core.Dto;


    [Route("api/[controller]")]
    [ApiController]
    public class GameCalendarController<GameCalendar, GameCalendarInput> : ControllerBase
        where GameCalendar : class, GameCalendarInput
        where GameCalendarInput : class
    {

    }
}
