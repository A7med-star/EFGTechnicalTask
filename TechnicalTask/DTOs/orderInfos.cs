
namespace TechnicalTask.DTOs
{
    public class orderInfos
    {
        public long orderID { get; set; }

        public string companyCode { get; set; }

        public short marketID { get; set; }

        public int securityID { get; set; }

        public DateTime orderDate { get; set; }

        public DateTime orderTime { get; set; }

        public int quantity { get; set; }

        public int executedQuantity { get; set; }

        public decimal price { get; set; }

    }
}
