namespace RPGCalendar.Controllers
{
    using Core.Dto;
    using Core.Services;

    public class GameNotificationController : BaseApiController<GameNotification, GameNotificationInput>
    {
        public GameNotificationController(IGameNotificationService service) :
            base(service)
        { }
    }
}
