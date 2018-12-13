﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    [TestFixture]
    public class ProductTests
    {
        readonly Product _product;
        private const int Id = 1;
        private const string Name = "Test";


        public ProductTests()
        {
            _product = new Product();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _product.Id = Id;

            Assert.That(_product.Id,
                Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetName()
        {
            _product.Name = Name;

            Assert.That(_product.Name,
                Is.EqualTo(Name));
        }
    }
}
