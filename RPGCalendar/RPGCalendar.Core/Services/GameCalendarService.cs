using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPGCalendar.Data;

namespace RPGCalendar.Core.Services
{
    public interface IGameCalendarService<GameCalendar, GameCalendarInput>
        where GameCalendar : Dto.GameCalendar
        where GameCalendarInput : Dto.GameCalendarInput
    {
        Task<GameCalendar> FetchByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
    public class GameCalendarService<GameCalendar, GameCalendarInput, TEntity> : IGameCalendarService<GameCalendar, GameCalendarInput>
        where TEntity : Data.GameCalendar
        where GameCalendar : Dto.GameCalendar
        where GameCalendarInput : Dto.GameCalendarInput
    {
        protected ApplicationDbContext DbContext { get; }

        protected IMapper Mapper { get; }

        protected virtual IQueryable<TEntity> Query => DbContext.Set<TEntity>();
        public GameCalendarService(ApplicationDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GameCalendar> FetchByIdAsync(int id)
        {
            return Mapper.Map<TEntity, GameCalendar>(await Query.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<bool> DeleteAsync(int id)
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
        //public async Task<GameCalendar> ProceedTime(int second);
    }
}
