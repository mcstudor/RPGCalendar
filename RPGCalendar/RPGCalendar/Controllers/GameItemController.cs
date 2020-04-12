namespace RPGCalendar.Controllers
{
    using Core.Dto;
    using Core.Services;

    public class GameItemController : BaseApiController<GameItem, GameItemInput>
    {
        public GameItemController(IGameItemService service) :
            base(service)
        {

        }
    }
}
