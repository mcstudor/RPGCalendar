using System;
using System.Collections.Generic;
using System.Text;

namespace RPGCalendar.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
