namespace DigitalShoppingBasket.Entities
{
    public class Product
    {
        public string ProductId { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;   

        public decimal UnitPrice { get; set; }
    }

}
