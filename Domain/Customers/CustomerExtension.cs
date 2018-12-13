using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Customers
{
    public static class CustomerExtensions
    {
        public static bool IsExisting(this Customer customer)
        {
            return customer.DateOfFirstPurchase.HasValue;
        }
    }
}
