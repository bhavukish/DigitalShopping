namespace DigitalShoppingBasket
{
    public class ProductDetails
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public Category Category { get; set; }

        public string? Summary { get; set; }
    }

    public enum Category
    {
        Fuel,
        Shop
    }
}
