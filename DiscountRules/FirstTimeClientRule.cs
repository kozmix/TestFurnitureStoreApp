using System;
using System.Collections.Generic;
using System.Text;
using Domain.Orders;
using Domain.Customers;

namespace DiscountRules
{
    public class FirstTimeClientRule : IDiscountRule
    {
        public decimal CalculateDiscount(Order order)
        {
            return !order.Customer.IsExisting() ? 0.07m : 0;
        }
    }
}
