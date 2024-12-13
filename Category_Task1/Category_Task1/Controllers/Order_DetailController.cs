using Category_Task1.Data;
using Category_Task1.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Category_Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order_DetailController : ControllerBase
    {

        // initializes a DataContext object in the Order_DetailController class
        // to be used in interacting with the database.
        private readonly DataContext _dbcontext;

        public Order_DetailController(DataContext context)
        {
            _dbcontext = context;
        }
        [HttpGet]

        public async Task<ActionResult<List<Order_Detail>>> GetAllOrderDetail()
        {
            //This function retrieves the list of order details from the database and returns a success result along with it.
            var orderDetail = await _dbcontext.Order_Details.ToListAsync();
            return Ok(orderDetail);
        }

        //This method handles an HTTP GET request with an id parameter passed through the URL.
        [HttpGet("{id}")]
        public async Task<ActionResult<Order_Detail>> GetOrder_Detail(int id)
        {
            //This method looks for a record in the "Order_Details" table based on the value of the id.
            var orderDetail = await _dbcontext.Order_Details.FindAsync(id);
            //Check if orderDetail exists and Order_Detail_Id.
            if (orderDetail?.Order_Detail_Id == null)
            {
                //If it doesn't exist or Order_Detail_Id is null,
                //return an HTTP error code 404 (Not Found) with the message "Order Detail not found".
                return NotFound("Order Detail not found");
            }
            //If orderDetail exists and Order_Detail_Id,
            //returns a successful result (HTTP 200 OK) along with the order details
            return Ok(orderDetail);
        }

        [HttpPost]
        public async Task<ActionResult<List<Order_Detail>>> AddOrder_Detail(Order_Detail orderDetail)
        {
            //Before adding orderDetail to the database,
            //check if an order detail with the same Order_Id already exists.
            //Because 1 Order only has 1 Order Detail
            var existingOrderDetail = await _dbcontext.Order_Details.FirstOrDefaultAsync(c => c.Order_Id == orderDetail.Order_Id);
            if (existingOrderDetail?.Order_Detail_Id != null)
            {
                //If it already exists, return an HTTP error code 400 (Bad Request) with the message
                //"The order id has been duplicated, please re-enter another Order Id."
                return BadRequest("The order id has been duplicated, please re-enter another Order Id.");
            }
            //Call method _dbcontext. Order_Details.Add(orderDetail) to add orderDetail to the "Order_Details" table.
            _dbcontext.Order_Details.Add(orderDetail);
            //Save the changes to the database.
            await _dbcontext.SaveChangesAsync();
            //returns the catalog list after it has been added.
            return Ok(await _dbcontext.Order_Details.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Order_Detail>>> UpdateOrder_Detail(Order_Detail updateOrder_Detail)
        {
            //Search for a record in the "Order_Details" table based on the value of the Order_Detail_Id to attach to the dbOrder_Detail
            var dbOrder_Detail = await _dbcontext.Order_Details.FindAsync(updateOrder_Detail.Order_Detail_Id);
            //Check if dbOrder_Detail exists and if Order_Detail_Id exists.
            if (dbOrder_Detail?.Order_Detail_Id == null)
            {
                //If it doesn't exist or Order_Detail_Id is null,
                //the method returns an HTTP error code 404 (Not Found) with the message "Order detail not found."
                return NotFound("Order detail not found");
            }
            //Before adding orderDetail to the database,
            //check if an order detail with the same Order_Id already exists.
            //Because 1 Order only has 1 Order Detail
            var existingOrderDetail = await _dbcontext.Order_Details.FirstOrDefaultAsync(c => c.Order_Id == updateOrder_Detail.Order_Id);
            if (existingOrderDetail?.Order_Detail_Id != null)
            {
                //If it already exists, return an HTTP error code 400 (Bad Request) with the message
                //"The order id has been duplicated, please re-enter another Order Id."
                return BadRequest("The order id has been duplicated, please re-enter another Order Id.");
            }
            // Update the information of a Order_Detail in the database.
            dbOrder_Detail.Order_Id = updateOrder_Detail.Order_Id;
            dbOrder_Detail.Product_Id = updateOrder_Detail.Product_Id;
            dbOrder_Detail.Order_Detail_Quantity = updateOrder_Detail.Order_Detail_Quantity;
            dbOrder_Detail.Order_Detail_Price = updateOrder_Detail.Order_Detail_Price;
            //Save the changes to the database.
            await _dbcontext.SaveChangesAsync();
            //returns the catalog list after it has been updated.
            return Ok(await _dbcontext.Order_Details.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Order_Detail>>> DeleteOrderDetail(int id)
        {
            //search the Order_Detail in the database based on the ID (id).
            var dbOrder_Detail = await _dbcontext.Order_Details.FindAsync(id);
            if (dbOrder_Detail?.Order_Detail_Id == null)  //(dbOrder_Detail is null)
            {
                //If the Order_Detail_Id with the corresponding ID is not found,
                //the method returns a 404 error code ("Order detail not found").
                return NotFound("Order detail not found");
            }
            //Delete the found (Order_Detail_Id-based) order details from the database.
            _dbcontext.Order_Details.Remove(dbOrder_Detail);
            //Save the changes to the database.
            await _dbcontext.SaveChangesAsync();
            //returns the catalog list after it has been deleted.
            return Ok(await _dbcontext.Order_Details.ToListAsync());
        }
    }
}
