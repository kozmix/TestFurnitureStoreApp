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
            
            if (!_customerRepository.EntityExists(selectedCustomer.Name))
            {
                return BadRequest(ModelState);
            }

            if (!_productRepository.EntityExists(selectedProduct.Name))
            {
                return BadRequest(ModelState);
            }

            //Order order = new Order();
            //order.Customer = selectedCustomer;
            //order.Product = selectedProduct;
            //order.Date = DateTime.Now;
            //order.Quantity = newOrder.Quantity;
            //order.UnitPrice = selectedProduct.Price;

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (_productRepository.EntityExists(newProduct.Name))
            //{
            //    return new JsonResult("productExists");
            //}

            //_productRepository.AddEntity(newProduct);
            //if (!_productRepository.Save())
            //{
            //    return StatusCode(500, "A problem happened while handling your request.");
            //}

            return Ok(newOrder);
        }
    }
}
