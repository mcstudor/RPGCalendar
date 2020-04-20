

namespace RPGCalendar.Data.GameObjects
{
    using System;

    public class Item : GameObject
    {
        private string _name = string.Empty;

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException(nameof(Name));
        }

        private string _description = string.Empty;

        public string Description
        {
            get => _description;
            set => _description = value ?? throw new ArgumentNullException(nameof(Description));
        }

        public int Quantity { get; set; }
        public decimal Quality { get; set; }
        public decimal QuantityDegradation { get; set; }
        public decimal QualityDegradation { get; set; }
    }
}
