using System.ComponentModel.DataAnnotations;

namespace Category_Task1.Model
{
    public class ProductModel
    {
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        public string ProductSize { get; set; }

        [Required]
        public string ProductColor { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double ProductPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ProductQuantity { get; set; }

        public string ProductDescription { get; set; }

        public string ProductImage { get; set; }

        public int? Id { get; set; }
    }
}
