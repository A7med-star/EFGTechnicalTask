using TechnicalTask.DTOs;
using TechnicalTask.Models;

namespace TechnicalTask.repoServices
{
    public interface IOrder
    {
        List<orderDTO> getAllOrdersWithFiltration(DateTime startDate, DateTime endDate, short? marketID = null, string companyCode = null, int? securityID = null);
        ordersModel deleteOrder(long id);

        ordersModel updateOrder(ordersModel updatedOrder);
        ordersModel createOrder(ordersModel order);
    }
}
