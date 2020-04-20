namespace RPGCalendar.Core.Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class GameInput
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required] 
        public string? GameSystem { get; set; }
        [Required]
        public GameCalendar? GameCalendar { get; set; }
    }
    public class Game : GameInput, IEntity
    {
        public int Id { get; set; }
        public int GameMaster { get; set; }
    }
}
