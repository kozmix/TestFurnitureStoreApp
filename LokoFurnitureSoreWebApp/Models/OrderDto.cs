using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStoreWebApp.Models
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int Quantity { get; set; }

        public int TotlaPrice { get; set; }
    }
}