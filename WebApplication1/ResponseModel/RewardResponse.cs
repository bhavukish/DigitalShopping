namespace DigitalShoppingBasket.ResponseModel
{
    public class RewardResponse
    {
        public string CustomerId { get; set; } = string.Empty;

        public string LoyaltyCard { get; set; } = string.Empty;

        public string TransactionDate { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public decimal DiscountApplied { get; set; }

        public decimal GrandTotal { get; set; }

        public decimal PointsEarned { get; set; }
    }

}
