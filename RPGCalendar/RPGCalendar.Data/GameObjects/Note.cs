namespace RPGCalendar.Data.GameObjects
{
    using System;

    public class Note : GameObject
    {

        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set => _title = value ?? throw new ArgumentNullException(nameof(Title));
        }

        private string _text = string.Empty;
        public string Text
        {
            get => _text;
            set => _text = value ?? throw new ArgumentNullException(nameof(Text));
        }

        public DateTime Date { get; set; }
    }
}
