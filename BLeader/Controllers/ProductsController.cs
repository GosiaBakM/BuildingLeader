using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IProductRepository = DAL.Repositories.Interfaces.IProductRepository;
using Product = DAL.Data.Entities.Product;

namespace BLeader.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    //[Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<IList<Product>> Get()
        {
            try
            {
                return Ok(_productRepository.GetAllProducts());
                //return Ok("ok");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products with exception: {ex}");
                return BadRequest("Failed to get products");
            }
        }

        [HttpGet]
        [Route("api/GetAll")]
        public ActionResult<IList<Product>> GetAll()
        {
            try
            {
                return Ok(_productRepository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products with exception: {ex}");
                return BadRequest("Failed to get products");
            }
        }
    }
}
