using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace TechnicalTask.Models
{
    public class invoicesModel
    {
        [Key]
        public long invoiceID { get; set; }

        public long? orderID { get; set; }

        public long? invoiceSerial { get; set; }

        public DateTime? invoiceDate { get; set; }

        public int? totalQuantity { get; set; }

        [Column(TypeName = "decimal(20, 3)")]
        public decimal? totalAmount { get; set; }

        [Column(TypeName = "decimal(20, 3)")]
        public decimal? totalOverHeads { get; set; }

        [Column(TypeName = "decimal(20, 3)")]
        public decimal? netAmount { get; set; }

        public bool isCancelled { get; set; }

        [MaxLength(100)]
        public string cancellationReason { get; set; }

        public DateTime? cancellationDate { get; set; }

        [ForeignKey("OrderID")]
        public virtual ordersModel? Order { get; set; }

        public virtual ICollection<executionsModel>? Executions { get; set; }
    }
}
