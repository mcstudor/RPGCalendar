namespace RPGCalendar.Data
{
    using System;

    public class User : FingerPrintEntityBase
    {
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value ?? throw new ArgumentNullException(nameof(FirstName));
        }

        private string _firstName = string.Empty;

        public string LastName
        {
            get => _lastName;
            set => _lastName = value ?? throw new ArgumentNullException(nameof(LastName));
        }

        private string _lastName = string.Empty;

        public string Email
        {
            get => _email; 
            set => _email = value ?? throw new ArgumentNullException(nameof(Email));
        }
        private string _email = string.Empty;

        public int? AcctId{ get; set; }
        public User? Acct { get; set; }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
