using System;
using System.Collections.Generic;
using System.Text;
using Domain.Orders;

namespace DiscountRules
{
    public class ProductOnSaleRule : IDiscountRule
    {
        public decimal CalculateDiscount(Order order)
        {
            decimal result = 0;

            if (order.Product.OnSale)
            {
                result = 0.2m;
            }

            return result;
        }
    }
}
