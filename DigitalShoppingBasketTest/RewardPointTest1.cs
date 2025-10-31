using DigitalShoppingBasket.Entities;
using DigitalShoppingBasket.RequestModel;
using DigitalShoppingBasket.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Xunit;


namespace DigitalShoppingBasketTest
{
    public class RewardPointTest1
    {
        private readonly RewardService _service;

        public RewardPointTest1()
        {
            var env = new FakeWebHostEnvironment();
            _service = new RewardService(env);
        }

        [Fact]
        public void Calculate_ShouldReturnCorrectTotals_WhenGivenSampleBasket()
        {
            var request = new RewardRequest
            {
                CustomerId = "CUST001",
                LoyaltyCard = "LOY001",
                TransactionDate = "2020-02-08",
                Basket = new List<Basket>
            {
                new() { ProductId = "PRD02", UnitPrice = 1.3M, Quantity = 2 },
                new() { ProductId = "PRD05", UnitPrice = 5.1M, Quantity = 1 }
            }
            };

            var result = _service.Calculate(request);

            Assert.NotNull(result);
            Assert.Equal("CUST001", result.CustomerId);
            Assert.True(result.TotalAmount > 0);
            Assert.True(result.GrandTotal <= result.TotalAmount);
            Assert.True(result.PointsEarned > 0);
        }
    }

    class FakeWebHostEnvironment : IWebHostEnvironment
    {
        public string ApplicationName { get; set; } = "DigitalShoppingBasket.Api";
        public IFileProvider WebRootFileProvider { get; set; } = default!;
        public string WebRootPath { get; set; } = string.Empty;
        public string EnvironmentName { get; set; } = Environments.Development;
        public string ContentRootPath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..", "net8.0");
        public IFileProvider ContentRootFileProvider { get; set; } = default!;
    }
}
