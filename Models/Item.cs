using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Train1_October.Models
{
    public class Item
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Item Price")]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
