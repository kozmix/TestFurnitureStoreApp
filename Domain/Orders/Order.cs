using Domain.Common;
using Domain.Customers;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class Order : IEntity
    {
        private int _quantity;
        private decimal _unitPrice;

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Customer Customer { get; set; }

        public Product Product { get; set; }

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                _unitPrice = value;

                UpdateTotalPrice();
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;

                UpdateTotalPrice();
            }
        }

        public decimal TotalPrice { get; private set; }

        private void UpdateTotalPrice()
        {
            TotalPrice = _unitPrice * _quantity;
        }
    }
}
