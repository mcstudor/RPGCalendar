namespace RPGCalendar.Core.Services
{
    using AutoMapper;
    using Data;

    public interface IGameService : IEntityService<Dto.Game, Dto.GameInput>
    {
    }
    public class GameService : EntityService<Dto.Game, Dto.GameInput, Game>, IGameService
    {
        public GameService(ApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }
    }
}
