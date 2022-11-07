
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IProductRepository = DAL.Repositories.Interfaces.IProductRepository;

namespace BLeader.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IProductRepository _productRepository;

        public OrdersController
        (
            ILogger<OrdersController> logger,
            IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }
    }
}
