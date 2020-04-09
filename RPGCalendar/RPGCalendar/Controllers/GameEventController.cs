
namespace RPGCalendar.Controllers
{
    using Core.Dto;
    using Core.Services;

    public class GameEventController : BaseApiController<GameEvent, GameEventInput>
    {
        public GameEventController(IGameEventService service) :
            base(service)
        { }
    }
}