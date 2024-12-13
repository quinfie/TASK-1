namespace Category_Task1.Entities
{
    public class Order_Detail
    {
        public int Order_Detail_Id { get; set; }
        public required int Order_Id { get; set;}
        public required int Product_Id { get; set; }

        public required int Order_Detail_Quantity { get; set; } 
        public required decimal Order_Detail_Price { get; set; }
    }
}
