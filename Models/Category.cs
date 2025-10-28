using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Train1_October.Models
{
    public class Category
    {
        [Required] 
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Item>? Items { get; set; }
    }
}
