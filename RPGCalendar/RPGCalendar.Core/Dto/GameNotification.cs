namespace RPGCalendar.Core.Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class GameNotificationInput
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
    }

    public class GameNotification : GameNotificationInput, IEntity
    {
        public int Id { get; set; }
    }
}
