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
        public int GameMaster { get; set; }
        public List<int>? Players { get; set; }
        [Required]
        public GameCalendar? GameCalendar { get; set; }
    }
    public class Game : GameInput
    {
        public int Id { get; set; }
    }
}
