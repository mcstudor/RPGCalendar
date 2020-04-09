namespace RPGCalendar.Data
{
    using System;
    using System.Collections.Generic;

    public class GameEvent : FingerPrintEntityBase
    {
        private string _title = string.Empty;

        public string Title
        {
            get => _title;
            set => _title = value ?? throw new ArgumentNullException(nameof(Title));
        }

        private string _description  = string.Empty;

        public string Description
        {
            get => _description;
            set => _description = value ?? throw new ArgumentNullException(nameof(Description));
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Surprise { get; set; }

    }
}
