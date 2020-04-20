namespace RPGCalendar.Data
{
    using System;
    using System.Collections.Generic;
    public class Game : FingerPrintEntityBase
    {
        private string _title = string.Empty;

        public string Title
        {
            get => _title;
            set => _title = value ?? throw new ArgumentNullException(nameof(Title));
        }

        //this property contains User id for a game master.
        public int GameMaster { get; set; }

        //this property is a list of player ids playing the game.
        public List<int> _players = new List<int>();

        //this property is current in game time. the type will be change after game calendar is implemented
        public GameCalendar? GameCalendar { get; set; }
    }
}
