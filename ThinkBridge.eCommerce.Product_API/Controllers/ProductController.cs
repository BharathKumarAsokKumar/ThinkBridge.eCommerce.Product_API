using CoreNLogText;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkBridge.eCommerce.Entity;
using ThinkBridge.eCommerce.Entity.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThinkBridge.eCommerce.Product_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private ProductDAL productDAL = null;
        private ILog logger;
        public ProductController(DBProductContext dbContext,ILog logger)
        {
            productDAL = new ProductDAL(dbContext);
            this.logger = logger;
        }
        
        // GET: api/<ProductController>
        [Route("GetProductbyName")]
        [HttpGet]
        public async Task<IActionResult> GetProductbyName([FromBody] Product product)
        {
            try
            {
                List<Product> productDetails = await Task.FromResult(productDAL.GetProductDetails(product));
                return Ok(productDetails);

            }
            catch(Exception e)
            {
                logger.Error(e.Message);
                return NotFound();
            }
        }

        // GET api/<ProductController>/5
        //[HttpGet("{id}")]
        [Route("GetAllProducts")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                List<Product> productDetails = await Task.FromResult(productDAL.GetProductDetails());
                return Ok(productDetails);
            }

            catch (Exception e)
            {
                logger.Error(e.Message);
                return NotFound();
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("PostProducts")]

        public async Task<IActionResult> PostProducts([FromBody] List<Product> product)
        {
            try
            {
                var result = await Task.FromResult(productDAL.AddProductetails(product));
                if (result == 1)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return NotFound();
            }
        }

        // PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        [Route("PutProducts")]

        public async Task<IActionResult> PutProducts(int id, [FromBody] Product product)
        {
            try
            {
                var result = await Task.FromResult(productDAL.UpdateProductDetails(id, product));
                if (result == 1)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                return NotFound();
            }
        }

        // DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        [Route("DeleteProducts")]

        public async Task<IActionResult> DeleteProducts(int id)
        {try
            {
                var result = await Task.FromResult(productDAL.RemoveProductDetails(id));
                if (result == 1)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex) { logger.Error(ex.Message); return NotFound(); }
        }
    }
}
