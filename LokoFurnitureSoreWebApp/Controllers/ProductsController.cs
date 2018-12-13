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
    public class ProductsController : ControllerBase
    {
        readonly IGenericRepository<Product> _productRepository;

        public ProductsController(IGenericRepository<Product> repository)
        {
            _productRepository = repository;
        }

        [HttpGet()]
        public IActionResult GetProducts()
        {
            List<Product> products = _productRepository.GetEntities().ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productRepository.GetEntity(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("create")]
        public IActionResult CreateProduct([FromBody]Product newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_productRepository.EntityExists(newProduct.Name))
            {
                return new JsonResult("productExists");
            }

            _productRepository.AddEntity(newProduct);
            if (!_productRepository.Save())
            { 
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok(newProduct);
        }
    }
}
