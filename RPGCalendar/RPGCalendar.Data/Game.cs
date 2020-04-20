namespace RPGCalendar.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using GameObjects;

    public class Game : FingerPrintEntityBase
    {
        public string Title
        {
            get => _title;
            set => _title = value ?? throw new ArgumentNullException(nameof(Title));
        }
        private string _title = string.Empty;

        public string Description
        {
            get => _description;
            set => _description = value ?? throw new ArgumentNullException(nameof(Description));
        }
        private string _description = string.Empty;

        public string GameSystem
        {
            get => _gameSystem;
            set => _gameSystem = value ?? throw new ArgumentNullException(nameof(GameSystem));
        }
        private string _gameSystem = string.Empty;
        public int GameMaster { get; set; }
        public DateTime GameTime { get; set; }

        //List of game items for game instance
        [NotMapped]
        public ICollection<User> Users { get; set; } = new HashSet<User>();
        [NotMapped]
        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();
        [NotMapped]
        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
        [NotMapped]
        public ICollection<Item> Items { get; set; } = new HashSet<Item>();
        [NotMapped]
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        [NotMapped]
        public ICollection<(Type, int)> CreatePermissions { get; set; } = new HashSet<(Type, int)>();

        public bool HasCreatePermissions(Type type, int userId) => 
            CreatePermissions.Contains((type, userId));
        public bool IsInGame(User user)
            => Users.Any(e => e == user);

        public void AddPlayer(User user)
            => Users.Add(user);
    }
}
