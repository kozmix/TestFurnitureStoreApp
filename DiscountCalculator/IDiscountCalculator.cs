using System;
using System.Collections.Generic;
using System.Text;
using Domain.Orders;

namespace DiscountCalculator
{
    public interface IDiscountCalculator
    {
        decimal CalculateDiscountPercentage(Order order);
    }
}
