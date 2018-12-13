using System;
using Domain.Orders;

namespace DiscountRules
{
    public class PremiumCustomerRule : IDiscountRule
    {
        public decimal CalculateDiscount(Order order)
        {
            return order.Customer.IsPremium ? 0.08m : 0;
        }
    }
}
