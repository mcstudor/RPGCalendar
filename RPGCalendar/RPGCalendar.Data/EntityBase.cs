using System.ComponentModel.DataAnnotations;

namespace RPGCalendar.Data
{
    public class EntityBase
    {
        [Required]
        public int id { get; protected set; }
    }
}
