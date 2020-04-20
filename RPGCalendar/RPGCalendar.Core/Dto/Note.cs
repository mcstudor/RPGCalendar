namespace RPGCalendar.Core.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NoteInput
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Text { get; set; }
        public DateTime Date { get; set; }

    }
    public class Note : NoteInput, IEntity
    {
        public int Id { get; set; }
    }
}
