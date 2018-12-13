using System;
using Domain.Orders;
using DiscountRules;
using System.Collections.Generic;

namespace DiscountCalculator
{
    // This concrete class implements the IDiscountCalculator, and returns the maximum discount that applies on an order.
    // Another example : We can implement another concrete class based on IDiscountCalculator, that could return the sum of discounts that apply on an order.
    public class DiscountCalculator : IDiscountCalculator
    {
        List<IDiscountRule> _rules = new List<IDiscountRule>();

        public DiscountCalculator()
        {
            _rules.Add(new NumberOfProductsRule(5, 0.12m));
            _rules.Add(new NumberOfProductsRule(10, 0.17m));
            _rules.Add(new NumberOfProductsRule(20, 0.22m));
            _rules.Add(new TotalAmoutOrderRule(500,  0.10m));
            _rules.Add(new TotalAmoutOrderRule(1000, 0.15m));
            _rules.Add(new TotalAmoutOrderRule(2000, 0.25m));
            _rules.Add(new FirstTimeClientRule()); // 0.07m
            _rules.Add(new PremiumCustomerRule()); // 0.08m
            _rules.Add(new ProductOnSaleRule()); // 0.2m
        }

        public decimal CalculateDiscountPercentage(Order order)
        {
            decimal discount = 0;

            foreach (var rule in _rules)
            {
                discount = Math.Max(rule.CalculateDiscount(order), discount);
            }

            return discount;
        }
    }
}
