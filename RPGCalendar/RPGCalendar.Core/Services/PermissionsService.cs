namespace RPGCalendar.Core.Services
{
    using System;
    using System.Threading.Tasks;
    using Data.GameObjects;
    using Dto;
    using Extensions;
    using Microsoft.AspNetCore.Http;
    using Game = Data.Game;

    public interface IPermissionsService<TGameEntity>
    where TGameEntity : GameObject
    {
        bool HasCreatePermissions();
        bool HasUpdatePermissions(TGameEntity gameEntity);
        bool HasReadPermissions(TGameEntity gameEntity);
        bool HasDeletePermissions(TGameEntity gameEntity);

    }
    public class PermissionsService<TGameEntity> : IPermissionsService<TGameEntity>
        where TGameEntity : GameObject
    {
        private readonly ISession _session;
        public PermissionsService(IHttpContextAccessor contextAccessor)
        {
            _session = contextAccessor.HttpContext.Session;
        }

        public bool HasReadPermissions(TGameEntity gameEntity) => 
            gameEntity.HasReadPermissions(GetUserId());

        public bool HasUpdatePermissions(TGameEntity gameEntity) =>
            gameEntity.HasUpdatePermissions(GetUserId());

        public bool HasDeletePermissions(TGameEntity gameEntity) =>
             gameEntity.HasDeletePermissions(GetUserId());

        public bool HasCreatePermissions()
        {
            return GetCurrentGame().HasCreatePermissions(typeof(TGameEntity), GetUserId());
            
        }

        private int GetUserId() =>
            _session.Get<Dto.User>("User")?.Id ?? throw new ArgumentNullException(nameof(User));

        private Game GetCurrentGame() =>
            _session.Get<Game>("Game") ?? throw new ArgumentNullException(nameof(Game));
    }
}
