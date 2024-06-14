using Microsoft.EntityFrameworkCore;
using System;
using TechnicalTask.Data;
using TechnicalTask.DTOs;
using TechnicalTask.Models;

namespace TechnicalTask.repoServices
{
    public class invoiceService : IInvoice
    {
        public taskDbContext context { get; set; }
        public invoiceService(taskDbContext _context)
        {
            context = _context;
        }
        public invoicesModel createInvoice(long orderID, invoicesModel invoice)
        {
            invoice.orderID = orderID;
            context.Invoices.Add(invoice);
            context.SaveChanges();

            return invoice;
        }

        public List<invoiceDTO> getAllInvoices()
        {
            var Invoices = context.Invoices.
                Include(i => i.Executions)
                .Include(i => i.Order)
                .Select(invoice=>new invoiceDTO
           {
               invoiceInfos = new invoiceInfos
               {
                   CancellationDate = invoice.cancellationDate,
                   CancellationReason = invoice.cancellationReason,
                   InvoiceDate  = invoice.invoiceDate,
                   InvoiceID = invoice.invoiceID,
                   InvoiceSerial = invoice.invoiceSerial,
                   IsCancelled = invoice.isCancelled,
                   NetAmount = invoice.netAmount,
                   OrderID=invoice.orderID,
                   TotalAmount = invoice.totalAmount,
                   TotalOverHeads = invoice.totalOverHeads,
                   TotalQuantity = invoice.totalQuantity,
               },
               order = new orderInfos
               {
                   orderID = invoice.Order.orderID,
                   companyCode = invoice.Order.companyCode,
                   marketID = invoice.Order.marketID,
                   securityID = invoice.Order.securityID,
                   orderDate = invoice.Order.orderDate,
                   orderTime = invoice.Order.orderTime,
                   quantity = invoice.Order.quantity,
                   executedQuantity = invoice.Order.executedQuantity,
                   price = invoice.Order.price
               },
               executions = invoice.Executions.Select(execution=> new executionInfos
               {
                   ExecutionID = execution.executionID,
                   InvoiceID = execution.invoiceID,
                   OperationDate = execution.operationDate,
                   OrderID = execution.orderID,
                   Price = execution.price,
                   Quantity = execution.quantity,
                   TotalAmount = execution.totalAmount
               }).ToList()

           }).ToList();

            return Invoices;
        }
    }
}
