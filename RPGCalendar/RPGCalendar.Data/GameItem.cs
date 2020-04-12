

namespace RPGCalendar.Data
{
    using System;
    using System.Collections.Generic;
    public class GameItem : FingerPrintEntityBase
    {
        private string _name = string.Empty;

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException(nameof(Name));
        }

        private string _descrption = string.Empty;

        public string Description
        {
            get => _descrption;
            set => _descrption = value ?? throw new ArgumentNullException(nameof(Description));
        }

        public int Quantity { get; set; }
        public decimal Quality { get; set; }
        public decimal QuanityDegration { get; set; }
        public decimal QualityDegration { get; set; }
    }
}
