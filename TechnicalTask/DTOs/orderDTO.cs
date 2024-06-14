using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalTask.DTOs
{
    public class orderDTO
    {
        public orderInfos? OrderInfos { get; set; }
        public List<executionInfos>?  Executions { get; set; } = new List<executionInfos>();
        public List<invoiceInfos>? Invoices { get; set; } = new List<invoiceInfos> ();
    }
}
