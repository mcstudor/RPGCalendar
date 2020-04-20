namespace RPGCalendar.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class RegistrationModel
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
