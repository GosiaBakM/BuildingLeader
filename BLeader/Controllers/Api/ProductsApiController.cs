using System;
using System.Collections.Generic;
using AutoMapper;
using DAL.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IProductRepository = DAL.Repositories.Interfaces.IProductRepository;

namespace BLeader.Controllers.Api
{
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        //private readonly IProductRepository _productRepository;

        public ProductsApiController(
            ILogger<ProductsController> logger,
            IProductRepository productRepository,
            IMapper _mapper)
        {
            _logger = logger;
            _productRepository = productRepository;
            this._mapper = _mapper;
        }

        [HttpGet]
        [Route("api/products")]

        public ActionResult<IList<Product>> Get()
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
