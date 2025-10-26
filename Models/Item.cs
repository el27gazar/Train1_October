using System.ComponentModel.DataAnnotations;

namespace Train1_October.Models
{
    public class Item
    {
        [Key]//Data Annotation to specify primary key
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Item Price")]
        public decimal Price { get; set; }
    }
}
