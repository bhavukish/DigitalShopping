namespace DigitalShoppingBasket.Entities
{
    public class PromotionPoints
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Category { get; set; } = string.Empty;

        public decimal Points { get; set; }
    }

}
