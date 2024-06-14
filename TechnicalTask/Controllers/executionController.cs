using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using TechnicalTask.DTOs;
using TechnicalTask.Models;
using TechnicalTask.repoServices;

namespace TechnicalTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class executionController : ControllerBase
    {
        public IExecution execution { get; }
        public executionController(IExecution _execution)
        {
            execution = _execution;
        }
        [HttpPost]
        public IActionResult createExecution(long orderId, executionsModel Execution)
        {
            if (ModelState.IsValid)
            {
                var newExecution = execution.createExecution(orderId, Execution);
                if (newExecution != null)
                {
                    return Created();
                }
                return BadRequest("No Execution has provided");
            }
            return BadRequest("wrong Validations");
        }
    }
}
