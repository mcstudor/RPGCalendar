
namespace RPGCalendar.Data
{
    using System.ComponentModel.DataAnnotations;
    public class EntityBase
    {
        [Required]
        [Key]
        public int Id { get; protected set; }
    }
}
