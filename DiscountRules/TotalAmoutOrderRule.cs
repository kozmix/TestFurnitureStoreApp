using System;
using System.Collections.Generic;
using System.Text;
using Domain.Orders;

namespace DiscountRules
{
    public class TotalAmoutOrderRule : IDiscountRule
    {
        private readonly int _totalAmount;
        private readonly decimal _discount;

        public TotalAmoutOrderRule(int totalAmount, decimal discount)
        {
            _totalAmount = totalAmount;
            _discount = discount;
        }

        public decimal CalculateDiscount(Order order)
        {
            decimal result = 0;

            if (order.TotalPrice >= _totalAmount)
            {
                result = _discount;
            }

            return result;
        }
    }
}
