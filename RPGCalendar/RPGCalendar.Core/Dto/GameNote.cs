namespace RPGCalendar.Core.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GameNoteInput
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Text { get; set; }
        public DateTime Date { get; set; }

    }
    public class GameNote : GameNoteInput, IEntity
    {
        public int Id { get; set; }
    }
}
