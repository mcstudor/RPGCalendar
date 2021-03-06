﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPGCalendar.Data;

namespace RPGCalendar.Core.Services
{
    public interface IEntityService<TDto, TInputDto>
        where TInputDto : class
        where TDto : class, TInputDto
    {
        Task<List<TDto>> FetchAllAsync();
        Task<TDto?> FetchByIdAsync(int id);
        Task<TDto?> InsertAsync(TInputDto entity);
        Task<TDto?> UpdateAsync(int id, TInputDto entity);
        Task<bool> DeleteAsync(int id);
    }

    public abstract class EntityService<TDto, TInputDto, TEntity> : IEntityService<TDto, TInputDto>
        where TEntity : EntityBase
        where TDto : class, TInputDto
        where TInputDto : class
    {
        protected ApplicationDbContext DbContext { get; }

        protected IMapper Mapper { get; }

        protected virtual IQueryable<TEntity> Query => DbContext.Set<TEntity>();

        public EntityService(ApplicationDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            TEntity entity = await Query.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is { })
            {
                DbContext.Remove(entity);
                await DbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public virtual async Task<List<TDto>> FetchAllAsync()
        {
            return Mapper.Map<List<TEntity>, List<TDto>>(await Query.ToListAsync());
        }

        public virtual async Task<TDto?> FetchByIdAsync(int id)
        {
            return Mapper.Map<TEntity, TDto>(await Query.FirstOrDefaultAsync(x => x.Id == id));
        }

        public virtual async Task<TDto?> InsertAsync(TInputDto dto)
        {
            TEntity entity = Mapper.Map<TInputDto, TEntity>(dto);
            DbContext.Add(entity);
            await DbContext.SaveChangesAsync();
            return Mapper.Map<TEntity, TDto>(entity);
        }

        public virtual async Task<TDto?> UpdateAsync(int id, TInputDto entity)
        {
            if (await Query.FirstOrDefaultAsync(x => x.Id == id) is TEntity result)
            {
                Mapper.Map(entity, result);
                await DbContext.SaveChangesAsync();
                return Mapper.Map<TEntity, TDto>(result);
            }
            return null;
        }
    }
}
