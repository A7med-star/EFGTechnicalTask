using TechnicalTask.DTOs;
using TechnicalTask.Models;

namespace TechnicalTask.repoServices
{
    public interface IExecution
    {
        executionsModel createExecution(long orderID,executionsModel execution);
    }
}
