namespace RPGCalendar.Core.Services
{
    using AutoMapper;
    using Data;

    public interface IGameEventService : IEntityService<Dto.GameEvent, Dto.GameEventInput>
    {
    }
    public class GameEventService : EntityService<Dto.GameEvent, Dto.GameEventInput, GameEvent>, IGameEventService
    {
        public GameEventService(ApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }
    }
    
}
