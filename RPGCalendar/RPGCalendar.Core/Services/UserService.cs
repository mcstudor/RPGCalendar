using System;
using System.Collections.Generic;
using System.Text;

namespace RPGCalendar.Core.Services
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Dto;
    using Microsoft.EntityFrameworkCore;
    using User = Data.User;

    public interface IUserService : IEntityService<Dto.User, Dto.UserInput>
    {
        public Task<Dto.User> GetUserByAuthId(string authId);
    }
    public class UserService : EntityService<Dto.User, Dto.UserInput, User>, IUserService
    {
        private readonly ISessionService _sessionService;

        public UserService(ApplicationDbContext dbContext, IMapper mapper, ISessionService sessionService)
            : base(dbContext, mapper)
        {
            _sessionService = sessionService;
        }

        public override Task<List<Dto.User>> FetchAllAsync()
        {
            return base.FetchAllAsync();
        }

        public override async Task<Dto.User?> FetchByIdAsync(int id)
        {
            var user = await Query.FirstOrDefaultAsync(x => x.Id == id);
            _sessionService.SetCurrentUser(user);
            return Mapper.Map<User, Dto.User>(user);
        }

        public override async Task<Dto.User?> InsertAsync(UserInput dto)
        {
            User user = Mapper.Map<UserInput, User>(dto);
            DbContext.Add(user);
            _sessionService.SetCurrentUser(user);
            await DbContext.SaveChangesAsync();
            return Mapper.Map<User, Dto.User>(user);
        }


        public async Task<Dto.User> GetUserByAuthId(string authId)
        {
            var user = await Query.FirstOrDefaultAsync(x => x.AuthId == authId);
            var mappedUser = Mapper.Map<User, Dto.User>(user);
            return mappedUser;
        }

    }
}
