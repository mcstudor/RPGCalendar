namespace RPGCalendar.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Data.GameObjects;
    using Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    public interface IGameObjectService<TDto, TInputDto> : IEntityService<TDto, TInputDto>
        where TInputDto : class
        where TDto : class, TInputDto
    { }
    public abstract class GameObjectService<TDto, TInputDto, TGameEntity> : EntityService<TDto, TInputDto, TGameEntity>
        where TGameEntity : GameObject
        where TDto : class, TInputDto
        where TInputDto : class
    {
        private readonly IPermissionsService<TGameEntity> _permissionService;
        protected GameObjectService(ApplicationDbContext dbContext, IMapper mapper, IPermissionsService<TGameEntity> permissionService) 
            : base(dbContext, mapper)
        {
            _permissionService = permissionService;
        }

        public override async Task<TDto?> UpdateAsync(int id, TInputDto entity)
        {
            
            var obj = await Query.FirstOrDefaultAsync(x => x.Id == id);
            if (!_permissionService.HasUpdatePermissions(obj))
                return null;
            return await base.UpdateAsync(id, entity);
        }

        public override async Task<List<TDto>> FetchAllAsync()
        {
            var filteredObjects =
                (await Query.ToListAsync()).Where(HasReadPermissions);
            return Mapper.Map<List<TGameEntity>, List<TDto>>(filteredObjects.ToList());
        }

        public override async Task<TDto?> FetchByIdAsync(int id)
        {
            var obj = await Query.FirstOrDefaultAsync(x => x.Id == id);
            if (!_permissionService.HasReadPermissions(obj))
                return default;
            return await base.FetchByIdAsync(id);
        }

        public override async Task<TDto?> InsertAsync(TInputDto dto)
        {
            return (_permissionService.HasCreatePermissions())
                ? await base.InsertAsync(dto)
                : null;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var obj = await Query.FirstOrDefaultAsync(x => x.Id == id);
            if (!_permissionService.HasDeletePermissions(obj))
                return false;
            return await base.DeleteAsync(id);
        }

        public bool HasReadPermissions(TGameEntity gameEntity)
            => _permissionService.HasReadPermissions(gameEntity);


    }
}
