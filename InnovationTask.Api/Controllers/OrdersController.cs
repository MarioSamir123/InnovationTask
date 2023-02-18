using InnovationTask.Core.Model;
using InnovationTask.Core.UOW;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace InnovationTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }
        [HttpGet]
        [Route("GetOrder/{id}")]
        public IActionResult GetOrder(int id)
        {
            Order order = _unitOfWork.Orders.GetByID(id);
            return (order == null) ? NotFound() : Ok(order);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Order> orders = _unitOfWork.Orders.GetAll().ToList();
            
            return (orders == null) ? NotFound() : Ok(orders);
        }
        [HttpPost]
        public IActionResult Add(Order order)
        {
            order = _unitOfWork.Orders.Add(order);
            _unitOfWork.Complete();
            return Ok(order);
        }
    }
}
