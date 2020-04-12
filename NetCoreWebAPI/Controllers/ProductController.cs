using System;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebAPI.DataAccess;
using NetCoreWebAPI.Entities;

namespace NetCoreWebAPI.Controllers
{
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        IProductDal _productDal;
        public ProductController(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productDal.GetList();
            return Ok(products);
        }
        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {
            try
            {
                var product = _productDal.Get(x => x.ProductId == productId);
                if (product==null)
                {
                    return NotFound($"There is no product with id = {productId}");
                } 
                return Ok(product);
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public IActionResult Post(Product product)
        {
            try
            {
                _productDal.Add(product);
                return new StatusCodeResult(201);
            }
            catch
            {

            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Put(Product product)
        {
            try
            {
                _productDal.Update(product);
                return Ok(product);
            }
            catch
            {

            }
            return BadRequest();
        }

        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            try
            {
                _productDal.Delete(new Product { ProductId = productId });
                return Ok();
            }
            catch
            {

            }
            return BadRequest();
        }
        [HttpGet("GetProductDetails")]
        public IActionResult GetProductWithDetails()
        {
            try
            {
                var result = _productDal.GetProductWithDetails();
                return Ok(result);
            }
            catch
            {

            }
            return BadRequest();
        }
    }
}