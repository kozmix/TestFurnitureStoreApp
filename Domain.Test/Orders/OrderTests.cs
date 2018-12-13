using Domain.Customers;
using Domain.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    [TestFixture]
    public class OrderTests
    {
        private Order _order;
        private Customer _customer;
        private Product _product;

        private const int Id = 1;
        private static readonly DateTime Date = new DateTime(2001, 2, 3);
        private const decimal UnitPrice = 1.00m;
        private const int Quantity = 1;

        [SetUp]
        public void SetUp()
        {
            _customer = new Customer();

            _product = new Product();

            _order = new Order();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _order.Id = Id;

            Assert.That(_order.Id,
                Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetDate()
        {
            _order.Date = Date;

            Assert.That(_order.Date,
                Is.EqualTo(Date));
        }

        [Test]
        public void TestSetAndGetCustomer()
        {
            _order.Customer = _customer;

            Assert.That(_order.Customer,
                Is.EqualTo(_customer));
        }

        [Test]
        public void TestSetAndGetProduct()
        {
            _order.Product = _product;

            Assert.That(_order.Product,
                Is.EqualTo(_product));
        }

        [Test]
        public void TestSetAndGetUnitPrice()
        {
            _order.UnitPrice = UnitPrice;

            Assert.That(_order.UnitPrice,
                Is.EqualTo(UnitPrice));
        }

        [Test]
        public void TestSetAndGetQuantity()
        {
            _order.Quantity = Quantity;

            Assert.That(_order.Quantity,
                Is.EqualTo(Quantity));
        }

        [Test]
        public void TestSetUnitPriceShouldRecomputeTotalPrice()
        {
            _order.Quantity = Quantity;

            _order.UnitPrice = 1.23m;

            Assert.That(_order.TotalPrice,
                Is.EqualTo(1.23));
        }

        [Test]
        public void TestSetQuantityShouldRecomputeTotalPrice()
        {
            _order.UnitPrice = UnitPrice;

            _order.Quantity = 2;

            Assert.That(_order.TotalPrice,
                Is.EqualTo(2.00m));
        }
    }
}
