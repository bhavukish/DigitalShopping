using DigitalShoppingBasket.Entities;
using DigitalShoppingBasket.Interfaces;
using DigitalShoppingBasket.RequestModel;
using DigitalShoppingBasket.ResponseModel;
using System.Text.Json;

namespace DigitalShoppingBasket.Services
{
    public class RewardService : IRewardService
    {
        private readonly string _dataPath;
        private readonly List<Product> _products;
        private readonly List<PromotionPoints> _pointsPromos;
        private readonly DiscountPromotionData _discounts;

        public RewardService(IWebHostEnvironment env)
        {
            _dataPath = Path.Combine(env.ContentRootPath, "SampleData");
            // load JSON files
            _products = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(Path.Combine(_dataPath, "products.json"))) ?? new();
            _pointsPromos = JsonSerializer.Deserialize<List<PromotionPoints>>(File.ReadAllText(Path.Combine(_dataPath, "points_promotions.json"))) ?? new();
            _discounts = JsonSerializer.Deserialize<DiscountPromotionData>(File.ReadAllText(Path.Combine(_dataPath, "discount_promotions.json"))) ?? new();
        }

        public RewardResponse Calculate(RewardRequest request)
        {
            DateTime txn;
            if (!DateTime.TryParse(request.TransactionDate, out txn))
            {
                // try parsing common formats
                txn = DateTime.ParseExact(request.TransactionDate, new[] { "dd-MMM-yyyy", "yyyy-MM-dd" }, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            }

            // determine active point promo (only one runs at a time as per spec)
            var activePoint = _pointsPromos.FirstOrDefault(p => txn >= p.StartDate && txn <= p.EndDate);

            var activeDiscounts = _discounts.Promotions.Where(p => txn >= p.StartDate && txn <= p.EndDate).ToList();

            decimal totalAmount = 0;
            decimal discountAmount = 0;
            decimal points = 0;

            foreach (var item in request.Basket)
            {
                var prod = _products.FirstOrDefault(p => p.ProductId == item.ProductId);
                if (prod == null) continue;

                decimal linePrice = prod.UnitPrice * item.Quantity;
                totalAmount += linePrice;

                // discounts for products eligible in active discount promos
                foreach (var dp in activeDiscounts)
                {
                    var eligible = _discounts.DiscountedProducts.Any(d => d.DiscountPromotionId == dp.Id && d.ProductId == prod.ProductId);
                    if (eligible)
                    {
                        discountAmount += linePrice * (dp.DiscountPercent / 100);
                        break;
                    }
                }

                // points
                if (activePoint != null)
                {
                    if (activePoint.Category.Equals("Any", StringComparison.OrdinalIgnoreCase) ||
                    activePoint.Category.Equals(prod.Category, StringComparison.OrdinalIgnoreCase))
                    {
                        points += linePrice * activePoint.Points;
                    }
                }
            }

            var grand = totalAmount - discountAmount;
            return new RewardResponse
            {
                CustomerId = request.CustomerId,
                LoyaltyCard = request.LoyaltyCard,
                TransactionDate = request.TransactionDate,
                TotalAmount = Math.Round(totalAmount, 2),
                DiscountApplied = Math.Round(discountAmount, 2),
                GrandTotal = Math.Round(grand, 2),
                PointsEarned = Math.Round(points, 2)
            };
        }
    }
}
