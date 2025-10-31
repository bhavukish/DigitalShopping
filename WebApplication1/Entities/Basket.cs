namespace DigitalShoppingBasket.Entities
{
    public class Basket
    {
        public string ProductId { get; set; } = string.Empty;

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
