
namespace TechnicalTask.DTOs
{
    public class invoiceInfos
    {
        public long InvoiceID { get; set; }

        public long? OrderID { get; set; }

        public long? InvoiceSerial { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public int? TotalQuantity { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? TotalOverHeads { get; set; }

        public decimal? NetAmount { get; set; }

        public bool IsCancelled { get; set; }

        public string CancellationReason { get; set; }

        public DateTime? CancellationDate { get; set; }
    }
}
