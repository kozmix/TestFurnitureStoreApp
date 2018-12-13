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
        public void Return15PctForNewCustomer()
        {
            var customerOrder = new Order();
            _customer = new Customer();
            _product = new Product();

            customerOrder.Customer = _customer;
            customerOrder.Product = _product;

            decimal discount = _calculator.CalculateDiscountPercentage(customerOrder);

            Assert.AreEqual(0.07m, discount);
        }

        //[Test]
        //public void Return10PctForVeteran()
        //{
        //    var customer = new Customer() { IsVeteran = true, DateOfFirstPurchase = DateTime.Today.AddDays(-1) };

        //    decimal discount = _calculator.CalculateDiscountPercentage(customer);

        //    Assert.AreEqual(0.1m, discount);
        //}

        //[Test]
        //public void Return5PctForSenior()
        //{
        //    var customer = new Customer() { DateOfBirth = DateTime.Today.AddYears(-65).AddDays(-5), DateOfFirstPurchase = DateTime.Today.AddDays(-1) };

        //    decimal discount = _calculator.CalculateDiscountPercentage(customer);

        //    Assert.AreEqual(0.05m, discount);
        //}

        //[Test]
        //public void Return10PctForBirthday()
        //{
        //    var customer = new Customer()
        //    {
        //        DateOfBirth = DateTime.Today,
        //        DateOfFirstPurchase = DateTime.Today.AddDays(-1)
        //    };

        //    decimal discount = _calculator.CalculateDiscountPercentage(customer);

        //   Assert.AreEqual(0.10m, discount);
        //}

        //[Test]
        //public void Return12PctFor5YearLoyalCustomer()
        //{
        //    var customer = new Customer() { DateOfBirth = DateTime.Today.AddDays(-5), DateOfFirstPurchase = DateTime.Today.AddYears(-5) };

        //    decimal discount = _calculator.CalculateDiscountPercentage(customer);

        //    Assert.AreEqual(0.12m, discount);
        //}

        //[Test]
        //public void Return22PctFor5YearLoyalCustomerOnBirthday()
        //{
        //    var customer = new Customer() { DateOfBirth = DateTime.Today, DateOfFirstPurchase = DateTime.Today.AddYears(-5) };

        //    decimal discount = _calculator.CalculateDiscountPercentage(customer);

        //    Assert.AreEqual(0.22m, discount);
        //}
    }
}
