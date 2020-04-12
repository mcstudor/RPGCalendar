namespace RPGCalendar.Core.Services
{
    using AutoMapper;
    using Data;

    public interface IGameItemService : IEntityService<Dto.GameItem, Dto.GameItemInput>
    {
    }

    public class GameItemService : EntityService<Dto.GameItem, Dto.GameItemInput, GameItem>, IGameItemService
    {
        public GameItemService(ApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }
    }
}
