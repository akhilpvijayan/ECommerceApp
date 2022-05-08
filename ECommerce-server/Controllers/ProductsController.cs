using ECommerce_App.Models;
using ECommerce_App.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductRepository productRepository;
        public ProductsController(IProductRepository _p)
        {
            productRepository = _p;
        }

        #region get products
        [HttpGet]
        [ProducesResponseType(typeof(Products), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productRepository.GetProducts();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        #endregion

        #region get product details by id
        [HttpGet]
        [ProducesResponseType(typeof(Products), 200)]
        [ProducesResponseType(404)]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var exp = await productRepository.GetProductById(id);
            if (exp == null)
            {
                return NotFound();
            }
            return Ok(exp);
        }
        #endregion

        #region add product
        [HttpPost]
        [ProducesResponseType(typeof(Products), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddProduct(Products product)
        {
            if (ModelState.IsValid)
            {
                var productId = await productRepository.AddProduct(product);
                if (productId != null)
                {
                    return Ok(productId);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        #endregion

        #region update product
        [HttpPut]
        [ProducesResponseType(typeof(Products), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateProduct(Products product)
        {
            if (ModelState.IsValid)
            {
                await productRepository.UpdateProduct(product);
                return Ok(product);
            }
            return BadRequest();
        }
        #endregion

        #region delete product
        [HttpDelete]
        [ProducesResponseType(typeof(Products), 200)]
        [ProducesResponseType(404)]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProductById(int id)
        {
            var exp = await productRepository.UpdateProductByActive(id);
            if (exp == null)
            {
                return NotFound();
            }
            return Ok(exp);
        }
        #endregion
    }
}

