namespace RPGCalendar.Core.Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class GameCalendarInput
    {

        [Required]
        public long inGameTime { get; set; }
        [Required]
        public int daysInYear { get; set; }
        [Required]
        public int monthsInYear { get; set; }
        [Required]
        public int daysInWeek { get; set; }
        //public List<Tuple<string, int>>? months { get; set; }
        //public List<string>? days { get; set; }
    }
    public class GameCalendar : GameCalendarInput, IEntity
    {
        public int Id { get; set; }
    }


}
