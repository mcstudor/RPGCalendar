namespace RPGCalendar.Core.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Dto;
    using Game = Data.Game;

    public interface IGameService : IEntityService<Dto.Game, Dto.GameInput>
    {
    }
    public class GameService : EntityService<Dto.Game, Dto.GameInput, Game>, IGameService
    {
        public GameService(ApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        { }

        public override Task<List<Dto.Game>> FetchAllAsync()
        {
            return base.FetchAllAsync();
        }
        public override Task<Dto.Game?> FetchByIdAsync(int id)
        {
            return base.FetchByIdAsync(id);
        }

        public override async Task<Dto.Game?> InsertAsync(GameInput dto)
        {
            Game entity = Mapper.Map<GameInput, Game>(dto);
            DbContext.Add(entity);
            await DbContext.SaveChangesAsync();
            return Mapper.Map<Game, Dto.Game>(entity);
        }

        public override Task<Dto.Game?> UpdateAsync(int id, GameInput entity)
        {
            return base.UpdateAsync(id, entity);
        }

        public override Task<bool> DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
    }
}
