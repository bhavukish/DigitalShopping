using DigitalShoppingBasket.Entities;

namespace DigitalShoppingBasket.RequestModel
{
    public class RewardRequest
    {
        public string CustomerId { get; set; } = string.Empty;

        public string LoyaltyCard { get; set; } = string.Empty;

        public string TransactionDate { get; set; } = string.Empty;

        public List<Basket> Basket { get; set; } = new();

    }
}
