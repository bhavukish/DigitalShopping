using DigitalShoppingBasket.RequestModel;
using DigitalShoppingBasket.ResponseModel;

namespace DigitalShoppingBasket.Interfaces
{
    public interface IRewardService
    {
        RewardResponse Calculate(RewardRequest request);
    }
}
