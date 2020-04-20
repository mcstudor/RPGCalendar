namespace RPGCalendar.Core
{
    using System.Reflection;
    using AutoMapper;
    using Data;

    public class AutomapperConfigurationProfile : Profile
    {
        public AutomapperConfigurationProfile()
        {
            CreateMap<Dto.GameNoteInput, GameNote>();
            CreateMap<GameNote, Dto.GameNote>();

            CreateMap<Dto.GameEventInput, GameEvent>();
            CreateMap<GameEvent, Dto.GameEvent>();

            CreateMap<Dto.GameItemInput, GameItem>();
            CreateMap<GameItem, Dto.GameItem>();

            CreateMap<Dto.GameNotificationInput, GameNotification>();
            CreateMap<GameNotification, Dto.GameNotification>();

            CreateMap<Dto.GameInput, Game>();
            CreateMap<Game, Dto.Game>();

/*            CreateMap<Dto.GameCalendarInput, GameCalendar>();
            CreateMap<GameCalendar, Dto.GameCalendar>();*/
        }

        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
