using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalTask.Models;
using TechnicalTask.repoServices;

namespace TechnicalTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        public IOrder order { get; }
        public orderController(IOrder _order) 
        { 
         order = _order;
        }
        [HttpGet]
        public IActionResult getFilteredOrders(DateTime startDate, DateTime endDate, short? marketID = null, string companyCode = null, int? securityID = null)
        {
            var Orders = order.getAllOrdersWithFiltration(startDate,endDate, marketID, companyCode, securityID);
            if (Orders != null)
            {
                return Ok(Orders);
            }
            return BadRequest("No elments exist");
        }
        [HttpPost]
        
        public IActionResult createOrder(ordersModel newOrder)
        {
            if (ModelState.IsValid)
            {
                var Order = order.createOrder(newOrder);
                if (Order != null)
                {
                    return Created();
                }
                return BadRequest("No Order has provided");
            }
            return BadRequest("wrong validations");
        }

        [HttpDelete]
        public IActionResult deleteOrder(long id)
        {
            var deletedOrder =order.deleteOrder(id);
            if (deletedOrder != null)
            {
                return NoContent();
            }
            return BadRequest("No Order with this id");
        }
        [HttpPut]
        public IActionResult updatedOrder(ordersModel updatedOrder)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("wrong validations");
            }
            var _updatedOrder = order.updateOrder(updatedOrder);
            if (_updatedOrder != null)
            {
                return Ok("Updated Successfullty");
            }
            return BadRequest("No Order has provided");
        }
    }
}
