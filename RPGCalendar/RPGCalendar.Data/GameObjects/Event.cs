namespace RPGCalendar.Data.GameObjects
{
    using System;

    public class Event : GameObject
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
