namespace RPGCalendar.Core.Services
{
    using AutoMapper;
    using Data;
    using Data.GameObjects;

    public interface IEventService : IGameObjectService<Dto.Event, Dto.EventInput>
    {
    }
    public class EventService : GameObjectService<Dto.Event, Dto.EventInput, Event>, IEventService
    {
        public EventService(ApplicationDbContext dbContext, IMapper mapper, IPermissionsService<Event> permissionsService)
            : base(dbContext, mapper, permissionsService)
        {
        }
    }
    
}
