using DiscountCalculator;
using Domain.Orders;
using FurnitureStoreWebApp.Data;
using FurnitureStoreWebApp.Models;
using FurnitureStoreWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LokoFurnitureSoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly IGenericRepository<Customer> _customerRepository;
        readonly IGenericRepository<Product> _productRepository;
        readonly IDiscountCalculator _discountCalculator;
            

        public OrdersController(IGenericRepository<Product> productRepo, IGenericRepository<Customer> customerRepo, IDiscountCalculator calculator)
        {
            _customerRepository = customerRepo;
            _productRepository = productRepo;
            _discountCalculator = calculator;
        }

        [HttpPost("calculate")]
        public IActionResult CalculateRebate([FromBody]OrderDto newOrder)
        {
            if (newOrder == null)
            {
                return BadRequest();
            }

            Customer selectedCustomer = _customerRepository.GetEntity(newOrder.CustomerId);
            Product selectedProduct = _productRepository.GetEntity(newOrder.ProductId);

            if (selectedCustomer == null)
            {
                return BadRequest(ModelState);
            }

            if (selectedProduct == null)
            {
                return BadRequest(ModelState);
            }

            // Here we should use a Mapper between two similar or almost similar models. For the moment it's done by hand.
            Domain.Products.Product mappedProduct = new Domain.Products.Product()
            {
                Id = selectedProduct.Id,
                Name = selectedProduct.Name,
                Price = selectedProduct.Price,
                OnSale = selectedProduct.OnSale

            };

            Domain.Customers.Customer mappedCustomer = new Domain.Customers.Customer()
            {
                Id = selectedProduct.Id,
                Name = selectedProduct.Name,
                IsPremium = selectedCustomer.IsPremium,
                DateOfFirstPurchase = selectedCustomer.DateOfFirstPurchase
            };

            Order order = new Order()
            {
                Product = mappedProduct,
                Customer = mappedCustomer,
                Quantity = newOrder.Quantity,
                UnitPrice = mappedProduct.Price
            };

            var resultDiscount = _discountCalculator.CalculateDiscountPercentage(order);
            var returnedValue = new JsonResult(resultDiscount);
            // return new JsonResult(resultDiscount)

            return Ok(resultDiscount);
        }
    }
}
