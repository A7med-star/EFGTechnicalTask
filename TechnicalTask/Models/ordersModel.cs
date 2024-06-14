using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalTask.Models
{
    public class ordersModel
    {
        [Key]
        public long orderID { get; set; }

        [StringLength(3)]
        public string companyCode { get; set; }

        public short marketID { get; set; }

        public int securityID { get; set; }

        public DateTime orderDate { get; set; }

        public DateTime orderTime { get; set; }

        public int quantity { get; set; }

        public int executedQuantity { get; set; }

        [Column(TypeName = "decimal(26, 9)")]
        public decimal price { get; set; }

        [Timestamp]
        public byte[]? rowVer { get; set; }

        public virtual ICollection<executionsModel>? Executions { get; set; }
        public virtual ICollection<invoicesModel>? Invoices { get; set; }
    }
}
