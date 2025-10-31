namespace DigitalShoppingBasket.Entities
{
    public class DiscountPromotion
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountPercent { get; set; }
    }

    public class DiscountedProduct
    {
        public string DiscountPromotionId { get; set; } = string.Empty;
        public string ProductId { get; set; } = string.Empty;
    }

    public class DiscountPromotionData
    {
        public List<DiscountPromotion> Promotions { get; set; } = new();
        public List<DiscountedProduct> DiscountedProducts { get; set; } = new();
    }
}
