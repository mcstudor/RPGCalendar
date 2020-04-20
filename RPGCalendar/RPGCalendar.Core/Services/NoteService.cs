namespace RPGCalendar.Core.Services
{
    using AutoMapper;
    using Data.GameObjects;
    using RPGCalendar.Data;

    public interface INoteService : IGameObjectService<Dto.Note, Dto.NoteInput>
    {
    }

    public class NoteService : GameObjectService<Dto.Note, Dto.NoteInput, Note>, INoteService
    {
        public NoteService(ApplicationDbContext dbContext, IMapper mapper, IPermissionsService<Note> permissionsService) 
            : base(dbContext, mapper, permissionsService)
        {
        }
    }
}
