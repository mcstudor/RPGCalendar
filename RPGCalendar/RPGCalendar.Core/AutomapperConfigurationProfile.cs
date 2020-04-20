namespace RPGCalendar.Core
{
    using System.Collections.Generic;
    using System.Reflection;
    using AutoMapper;
    using Data;
    using Data.GameObjects;

    public class AutomapperConfigurationProfile : Profile
    {
        public AutomapperConfigurationProfile()
        {
            CreateMap<Dto.NoteInput, Note>();
            CreateMap<Note, Dto.Note>();

            CreateMap<Dto.EventInput, Event>();
            CreateMap<Event, Dto.Event>();

            CreateMap<Dto.ItemInput, Item>();
            CreateMap<Item, Dto.Item>();

            CreateMap<Dto.NotificationInput, Notification>();
            CreateMap<Notification, Dto.Notification>();

            CreateMap<Dto.GameInput, Game>();
            CreateMap<Game, Dto.Game>();

            CreateMap<Dto.UserInput, User>();
            CreateMap<User, Dto.User>().ForMember(des => des.AuthId, 
                opt => opt.Ignore());
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
