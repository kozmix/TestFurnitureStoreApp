using Domain.Orders;

namespace DiscountRules
{
    public interface IDiscountRule
    {
        decimal CalculateDiscount(Order order);
    }
}
