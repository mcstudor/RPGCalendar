using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCalendar.Data
{
    public class User : FingerPrintEntityBase
    {
        public string FirstName { get => _FirstName; set => _FirstName = value ?? throw new ArgumentNullException(nameof(FirstName)); }
        private string _FirstName = string.Empty;
        public string LastName { get => _LastName; set => _LastName = value ?? throw new ArgumentNullException(nameof(LastName)); }
        private string _LastName = string.Empty;
        public string Email { get => _Email; set => _Email = value ?? throw new ArgumentNullException(nameof(LastName)); }
        private string _Email = string.Empty;

        public int? AccntId{ get; set; }
        public User? Accnt { get; set; }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
