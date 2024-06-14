using TechnicalTask.DTOs;
using TechnicalTask.Models;

namespace TechnicalTask.repoServices
{
    public interface IInvoice
    {
        List<invoiceDTO> getAllInvoices();
        invoicesModel createInvoice(long orderID, invoicesModel invoice);
    }
}
