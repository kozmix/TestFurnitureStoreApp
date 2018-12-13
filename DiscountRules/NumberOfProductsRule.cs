using System;
using System.Collections.Generic;
using System.Text;
using Domain.Orders;

namespace DiscountRules
{
    public class NumberOfProductsRule : IDiscountRule
    {
        private readonly int _numberOfProducts;
        private readonly decimal _discount;

        public NumberOfProductsRule(int numberOfProducts, decimal discount)
        {
            _numberOfProducts = numberOfProducts;
            _discount = discount;
        }

        public decimal CalculateDiscount(Order order)
        {
            decimal result = 0;

            if (order.Quantity >= _numberOfProducts)
            {
                result = _discount;
            }

            return result;
        }
    }
}
