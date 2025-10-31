using DigitalShoppingBasket;
using DigitalShoppingBasket.Interfaces;
using DigitalShoppingBasket.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DigitalShoppingBasket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RewardController : ControllerBase
    {
        
        private readonly IRewardService _service;

        public RewardController(IRewardService service)
        {
            _service = service;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] RewardRequest request)
        {
            if (request == null || request.Basket == null || !request.Basket.Any())
                return BadRequest(new { error = "Invalid request: missing basket items." });

            var result = _service.Calculate(request);
            return Ok(result);
        }

    }
}
