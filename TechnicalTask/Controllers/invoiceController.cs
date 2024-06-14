using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalTask.Models;
using TechnicalTask.repoServices;

namespace TechnicalTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class invoiceController : ControllerBase
    {
        public IInvoice invoice { get; }
        public invoiceController(IInvoice _invoice)
        {
            invoice = _invoice;
        }
        [HttpGet]
        public IActionResult getAllInvoices()
        {
            var invoices = invoice.getAllInvoices();
            if (invoices != null)
            {
                return Ok(invoices);
            }
            return BadRequest("No invoices provided");
        }
        [HttpPost]
        public IActionResult createInvoice(long orderId,invoicesModel Invoice)
        {
            if (ModelState.IsValid)
            {
                var newInvoice = invoice.createInvoice(orderId, Invoice);
                if (newInvoice != null)
                {
                    return Created();
                }
                return BadRequest("No Invoice has provided");
            }
            return BadRequest("wrong Validation");
        }
    }
}
