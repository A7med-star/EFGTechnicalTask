using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechnicalTask.Models
{
    public class executionsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int executionID { get; set; }

        public long? invoiceID { get; set; }

        public long? orderID { get; set; }

        public DateTime operationDate { get; set; }

        public int quantity { get; set; }

        [Column(TypeName = "decimal(20, 6)")]
        public decimal price { get; set; }

        [Column(TypeName = "decimal(20, 4)")]
        public decimal totalAmount { get; set; }

        [Timestamp]
        public byte[]? rowVer { get; set; }

        [ForeignKey("OrderID")]
        public virtual ordersModel? Order { get; set; }

        [ForeignKey("InvoiceID")]
        public virtual invoicesModel? Invoice { get; set; }
    }
}
