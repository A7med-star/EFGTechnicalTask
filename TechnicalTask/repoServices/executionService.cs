using Microsoft.EntityFrameworkCore;
using TechnicalTask.Data;
using TechnicalTask.DTOs;
using TechnicalTask.Models;

namespace TechnicalTask.repoServices
{
    public class executionService : IExecution
    {
        public taskDbContext context { get; set; }
        public executionService(taskDbContext _context)
        {
            context = _context;
        }
        public executionsModel createExecution(long orderID, executionsModel execution)
        {
            execution.orderID = orderID;
            context.Executions.Add(execution);
            context.SaveChanges();

            return execution;
        }

    }
}
