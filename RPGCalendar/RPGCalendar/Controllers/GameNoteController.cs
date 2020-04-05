
namespace RPGCalendar.Controllers
{
    using Core.Dto;
    using Core.Services;
    public class GameNoteController : BaseApiController<GameNote, GameNoteInput>
    {
        public GameNoteController(IGameNoteService service) : 
            base(service)
        { }
    }
}