using Microsoft.AspNetCore.Mvc;
using UltimusTest.Interfaces.Repository;
using UltimusTest.Interfaces.Service;
using UltimusTest.Models;

namespace UltimusTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
       
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpGet]
        public List<OrderDTOOut> Get()
        {
            return _orderService.GetOrders();
        }

        [HttpPost]
        public OrderDTOOut Add([FromBody]OrderDTOIn model)
        {
            return _orderService.AddOrder(model);
        }
    }
}