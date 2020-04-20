namespace RPGCalendar.Core.Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class ItemInput
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Quality { get; set; }
        [Required]
        public decimal QuanityDegration { get; set; }
        [Required]
        public decimal QualityDegration { get; set; }
    }

    public class Item : ItemInput, IEntity
    {
        public int Id { get; set; }
    }
}
