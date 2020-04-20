using System;
using System.Collections.Generic;
using System.Text;

namespace RPGCalendar.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [EmailAddress]
        public string? Email { get; set; }

        public string? Username { get; set; }
        
        [Required]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
