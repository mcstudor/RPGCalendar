namespace RPGCalendar.Data
{
    using System;
    using System.Collections.Generic;

    public class GameCalendar : FingerPrintEntityBase
    {
        //current time in the game.
        public long inGameTime { get; set; }
        //how many days in a year.
        public int daysInYear { get; set; }
        //how many months in a year.
        public int monthsInYear { get; set; }
        //how many days in a week.
        public int daysInWeek { get; set; }
        //<fictional name of the month, how many days in that month>
        //public List<Tuple<string,int>>? months { get; set; }
        //fictional name of the day.
        //public List<string>? days { get; set; }
    }
}
