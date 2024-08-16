using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Category_Task1.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public double OrderTotalPrice { get; set; }
        public string OrderPaymentMethod { get; set; } = string.Empty;
        public string OrderShippingAddress { get; set; } = string.Empty;
        public int EmployeeId { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }

}