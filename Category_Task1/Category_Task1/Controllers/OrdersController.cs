using Category_Task1.Data;
using Category_Task1.Entities;
using Category_Task1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Category_Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAllOrders()
        {
            var lsOrder = _context.Orders;
            return Ok(lsOrder);
        }

        [HttpGet("{id}")]
        public ActionResult GetByIdOrder(int id)
        {
            var order = _context.Orders.SingleOrDefault(p => p.OrderId == id);
            if (order != null)
            {
                return Ok(order);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateOrder(OrderModel orderModel)
        {
            try
            {
                var order = new Order
                {
                    OrderDate = orderModel.OrderDate,
                    OrderPaymentMethod = orderModel.OrderPaymentMethod,
                    OrderShippingAddress = orderModel.OrderShippingAddress,
                    OrderStatus = orderModel.OrderStatus,
                    OrderTotalPrice = orderModel.OrderTotalPrice,
                    EmployeeId = orderModel.EmployeeId,
                };
                _context.Orders.Add(order);
                _context.SaveChanges();
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, OrderModel orderModel)
        {
            var order = _context.Orders.SingleOrDefault(p => p.OrderId == id);
            if (order != null)
            {
                order.OrderDate = orderModel.OrderDate;
                order.OrderPaymentMethod = orderModel.OrderPaymentMethod;
                order.OrderShippingAddress = orderModel.OrderShippingAddress;
                order.OrderStatus = orderModel.OrderStatus;
                order.OrderTotalPrice = orderModel.OrderTotalPrice;
                order.EmployeeId = orderModel.EmployeeId;
                _context.SaveChanges();
                return Ok(order);
            }
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var order = _context.Orders.SingleOrDefault(p => p.OrderId == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}