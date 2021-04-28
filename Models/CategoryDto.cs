using System.ComponentModel.DataAnnotations;

namespace cappuccino.shifttracker.Models
{
    public class CategoryDto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
    }
}