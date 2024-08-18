using Category_Task1.Data;
using Category_Task1.Entities;
using Category_Task1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

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
        public async Task<ActionResult> GetAllOrders()
        {
            var lsOrder = await _context.Orders.ToListAsync();
            return Ok(lsOrder);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdOrder(int id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(p => p.OrderId == id);
            if (order != null)
            {
                return Ok(order);
            }
            return BadRequest("Đơn hàng không tồn tại!");
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(OrderModel orderModel)
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

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, OrderModel orderModel)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(p => p.OrderId == id);
            if (order != null)
            {
                order.OrderDate = orderModel.OrderDate;
                order.OrderPaymentMethod = orderModel.OrderPaymentMethod;
                order.OrderShippingAddress = orderModel.OrderShippingAddress;
                order.OrderStatus = orderModel.OrderStatus;
                order.OrderTotalPrice = orderModel.OrderTotalPrice;
                order.EmployeeId = orderModel.EmployeeId;

                await _context.SaveChangesAsync();
                return Ok(order);
            }
            else
                return BadRequest("Đơn hàng không tồn tại!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(p => p.OrderId == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return Ok("Xóa đơn hàng thành công!");
            }
            return BadRequest("Đơn hàng không tồn tại!");
        }
    }
}