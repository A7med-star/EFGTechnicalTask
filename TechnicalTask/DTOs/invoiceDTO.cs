

namespace TechnicalTask.DTOs
{
    public class invoiceDTO
    {
      
        public invoiceInfos invoiceInfos { get; set; }

        public orderInfos order { get; set; }
        public List<executionInfos> executions { get; set; } = new List<executionInfos>();
    }
}
