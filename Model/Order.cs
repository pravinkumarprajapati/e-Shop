namespace OrderServices.Model
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Inventory
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class Payment
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
