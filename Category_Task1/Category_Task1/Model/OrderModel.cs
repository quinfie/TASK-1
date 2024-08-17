namespace Category_Task1.Model
{
    public class OrderModel
    {
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public double OrderTotalPrice { get; set; }
        public string OrderPaymentMethod { get; set; } = string.Empty;
        public string OrderShippingAddress { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
    }
}
