
namespace RPGCalendar.Data
{
    using System.ComponentModel.DataAnnotations;
    public class EntityBase
    {
        [Required]
        public int Id { get; protected set; }
    }
}
