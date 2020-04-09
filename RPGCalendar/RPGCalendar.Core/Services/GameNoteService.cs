namespace RPGCalendar.Core.Services
{
    using AutoMapper;
    using RPGCalendar.Data;

    public interface IGameNoteService : IEntityService<Dto.GameNote, Dto.GameNoteInput>
    {
    }

    public class GameNoteService : EntityService<Dto.GameNote, Dto.GameNoteInput, GameNote>, IGameNoteService
    {
        public GameNoteService(ApplicationDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }
    }
}
