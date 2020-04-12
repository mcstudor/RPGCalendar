namespace RPGCalendar.Controllers
{
    using Core.Dto;
    using Core.Services;

    public class GameController : BaseApiController<Game, GameInput>
    {
        public GameController(IGameService service) :
            base(service)
        { }
    }
}
