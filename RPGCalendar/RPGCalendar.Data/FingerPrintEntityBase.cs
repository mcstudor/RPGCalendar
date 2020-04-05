namespace RPGCalendar.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FingerPrintEntityBase : EntityBase
    {
        [Required]
        public string? CreatedBy { get; internal set; }
        [Required]
        public DateTime CreatedOn { get; internal set; }
        [Required]
        public string? ModifiedBy { get; internal set; }
        [Required]
        public DateTime ModifiedOn { get; internal set; }
    }
}
