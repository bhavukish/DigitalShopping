namespace DigitalShoppingBasket.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        public string LoyaltyCard { get; set; }

        public DateTime TransactionDate { get; set; }

        public List<Basket> Basket { get; set; }
    }
}
