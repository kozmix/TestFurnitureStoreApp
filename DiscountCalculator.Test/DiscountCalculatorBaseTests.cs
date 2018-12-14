using System;
using Domain.Customers;
using Domain.Orders;
using Domain.Products;
using NUnit.Framework;

namespace DiscountCalculator.Test
{
    [TestFixture]
    public abstract class DiscountCalculatorBaseTests<T>
        where T : IDiscountCalculator, new()
    {
        private IDiscountCalculator _calculator;

        private Order _order;
        private Customer _customer;
        private Product _product;

        [SetUp]
        public void SetUp()
        {
            _calculator = new T();
        }

        [Test]
        public void Return07ForFirsTimeCustomer()
        {
            var customerOrder = new Order();
            _customer = new Customer();
            _product = new Product();

            customerOrder.Customer = _customer;
            customerOrder.Product = _product;

            decimal discount = _calculator.CalculateDiscountPercentage(customerOrder);

            Assert.AreEqual(0.07m, discount);
        }

        [Test]
        public void Return02ForProductOnSale()
        {
            var customerOrder = new Order();
            _customer = new Customer();
            _product = new Product() { OnSale = true };

            customerOrder.Customer = _customer;
            customerOrder.Product = _product;            

            decimal discount = _calculator.CalculateDiscountPercentage(customerOrder);

            Assert.AreEqual(0.2m, discount);
        }

        [Test]
        public void Return08ForPremiumCustomer()
        {
            var customerOrder = new Order();
            _customer = new Customer() { IsPremium = true };
            _product = new Product();

            customerOrder.Customer = _customer;
            customerOrder.Product = _product;

            decimal discount = _calculator.CalculateDiscountPercentage(customerOrder);

            Assert.AreEqual(0.08m, discount);
        }

        [Test]
        public void Return12PctFor6Products()
        {
            var customerOrder = new Order();
            _customer = new Customer();
            _product = new Product();

            customerOrder.Customer = _customer;
            customerOrder.Product = _product;
            customerOrder.Quantity = 6;

            decimal discount = _calculator.CalculateDiscountPercentage(customerOrder);

            Assert.AreEqual(0.12m, discount);
        }

        [Test]
        public void Return17PctFor12Products()
        {
            var customerOrder = new Order();
            _customer = new Customer();
            _product = new Product();

            customerOrder.Customer = _customer;
            customerOrder.Product = _product;
            customerOrder.Quantity = 12;

            decimal discount = _calculator.CalculateDiscountPercentage(customerOrder);

            Assert.AreEqual(0.17m, discount);
        }

        [Test]
        public void Return22PctFor21Products()
        {
            var customerOrder = new Order();
            _customer = new Customer();
            _product = new Product();

            customerOrder.Customer = _customer;
            customerOrder.Product = _product;
            customerOrder.Quantity = 21;

            decimal discount = _calculator.CalculateDiscountPercentage(customerOrder);

            Assert.AreEqual(0.22m, discount);
        }

        [Test]
        public void Return10PctForOrderOver500()
        {
            var customerOrder = new Order();
            _customer = new Customer();
            _product = new Product();

            customerOrder.Customer = _customer;
            customerOrder.Product = _product;
            customerOrder.UnitPrice = 200;
            customerOrder.Quantity = 3;

            decimal discount = _calculator.CalculateDiscountPercentage(customerOrder);

            Assert.AreEqual(0.10m, discount);
        }

        [Test]
        public void Return15PctForOrderOver1000()
        {
            var customerOrder = new Order();
            _customer = new Customer();
            _product = new Product();

            customerOrder.Customer = _customer;
            customerOrder.Product = _product;
            customerOrder.UnitPrice = 250;
            customerOrder.Quantity = 5;

            decimal discount = _calculator.CalculateDiscountPercentage(customerOrder);

            Assert.AreEqual(0.15m, discount);
        }

        [Test]
        public void Return25PctForOrderOver2000()
        {
            var customerOrder = new Order();
            _customer = new Customer();
            _product = new Product();

            customerOrder.Customer = _customer;
            customerOrder.Product = _product;
            customerOrder.UnitPrice = 300;
            customerOrder.Quantity = 7;

            decimal discount = _calculator.CalculateDiscountPercentage(customerOrder);

            Assert.AreEqual(0.25m, discount);
        }
    }
}
