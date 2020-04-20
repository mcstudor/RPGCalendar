namespace RPGCalendar.Core.Services
{
    using Data;
    using Data.Exceptions;
    using Extensions;
    using Microsoft.AspNetCore.Http;

    public interface ISessionService
    {
        void SetCurrentUser(User user);
        User GetCurrentUser();
        void ClearSessionUser();
        void SetCurrentGame(Game game);
        Game GetCurrentGame();
        void ClearSessionGame();
    }
    public class SessionService : ISessionService
    {
        private readonly ISession _session;
        private const string UserKey = "User";
        private const string GameKey = "Game";
        public SessionService(IHttpContextAccessor contextAccessor)
        {
            _session = contextAccessor.HttpContext.Session;
        }

        public void SetCurrentUser(User user)
            => _session.Set(UserKey, user);

        public User GetCurrentUser()
            => _session.Get<User>(UserKey) ?? throw new IllegalStateException(nameof(User));

        public void ClearSessionUser()
            => _session.Remove(UserKey);

        public void SetCurrentGame(Game game)
            => _session.Set(GameKey, game);

        public Game GetCurrentGame()
            => _session.Get<Game>(GameKey) ?? throw new IllegalStateException(nameof(Game));

        public void ClearSessionGame()
            => _session.Remove(GameKey);
    }
}
