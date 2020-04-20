namespace RPGCalendar.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class User : FingerPrintEntityBase
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
        private string _authId = string.Empty;

        public string AuthId
        {
            get => _authId;
            set => _authId = value ?? throw new ArgumentNullException(nameof(AuthId));
        }

        public ICollection<Game> Games { get; set; } = new HashSet<Game>();

        public User(string email, string authId)
        {
            Email = email;
            AuthId = authId;
        }
    }
}
