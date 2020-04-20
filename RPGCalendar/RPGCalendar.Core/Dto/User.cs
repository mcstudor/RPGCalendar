namespace RPGCalendar.Core.Dto
{
    using System;
    using System.Collections.Generic;

    public class UserInput
    {
        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set => _username = value ?? throw new ArgumentNullException(nameof(Username));
        }

        private string _email = string.Empty;

        public string Email
        {
            get => _email;
            set => _email = value ?? throw new ArgumentNullException(nameof(Email));
        }

        public string? AuthId { get; set; }

        public ICollection<Game> Games { get; set; } = new List<Game>();
    }

    public class User : UserInput, IEntity
    {
        public int Id { get; set; }
    }
}
