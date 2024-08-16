using System.ComponentModel.DataAnnotations.Schema;

namespace Category_Task1.Entities
{

    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderDetailQuantity { get; set; }
        public double OrderDetailPrice { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
