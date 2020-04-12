namespace RPGCalendar.Core.Services
{
    using AutoMapper;
    using Data;

    public interface IGameNotificationService : IEntityService<Dto.GameNotification, Dto.GameNotificationInput>
    {

    }

    public class GameNotificationService : EntityService<Dto.GameNotification, Dto.GameNotificationInput, GameNotification>, IGameNotificationService
    {
        public GameNotificationService(ApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }
    }
}
