
namespace TechnicalTask.DTOs
{
    public class executionInfos
    {
        public int ExecutionID { get; set; }

        public long? InvoiceID { get; set; }

        public long? OrderID { get; set; }

        public DateTime? OperationDate { get; set; }

        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
