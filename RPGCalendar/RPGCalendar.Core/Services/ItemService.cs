namespace RPGCalendar.Core.Services
{
    using AutoMapper;
    using Data;
    using Data.GameObjects;

    public interface IItemService : IGameObjectService<Dto.Item, Dto.ItemInput>
    {
    }

    public class ItemService : GameObjectService<Dto.Item, Dto.ItemInput, Item>, IItemService
    {
        public ItemService(ApplicationDbContext dbContext, IMapper mapper, IPermissionsService<Item> permissionsService)
            : base(dbContext, mapper, permissionsService)
        {
        }
    }
}
