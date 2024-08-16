using System.ComponentModel.DataAnnotations;

namespace Category_Task1.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Product>? Products { get; set; }

    }
}
