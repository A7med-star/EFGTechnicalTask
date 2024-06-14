using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TechnicalTask.Data;
using TechnicalTask.DTOs;
using TechnicalTask.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TechnicalTask.repoServices
{
    public class orderService:IOrder
    {
        public taskDbContext context { get; set; }
        public orderService(taskDbContext _context)
        {
            context = _context;
        }
        public List<orderDTO> getAllOrdersWithFiltration(DateTime startDate, DateTime endDate, short? marketID = null, string companyCode = null, int? securityID = null)
        {

            var filterdOrders = context.Orders
                .Include(o => o.Invoices)
                .Include(o => o.Executions)
                .Where(o => o.orderDate >= startDate && o.orderDate <= endDate);

            if(marketID != null)
            {
                filterdOrders = filterdOrders.Where(o => o.marketID == marketID.Value);
            }
            if(!string.IsNullOrEmpty(companyCode))
            {
                filterdOrders = filterdOrders.Where(o => o.companyCode == companyCode);
            }
            if(securityID != null)
            {
                filterdOrders = filterdOrders.Where(o => o.securityID == securityID.Value);
            }
            var filteredOrdersDTO = filterdOrders.Select(order => new orderDTO
            {
                OrderInfos = new orderInfos
                {
                    orderID = order.orderID,
                    companyCode = order.companyCode,
                    marketID = order.marketID,
                    securityID = order.securityID,
                    orderDate = order.orderDate,
                    orderTime = order.orderTime,
                    quantity = order.quantity,
                    executedQuantity = order.executedQuantity,
                    price = order.price
                },
                Executions = order.Executions.Select(executionModel => new executionInfos
                {
                    ExecutionID = executionModel.executionID,
                    InvoiceID = executionModel.invoiceID,
                    OperationDate = executionModel.operationDate,
                    OrderID = executionModel.orderID,
                    Price = executionModel.price,
                    Quantity = executionModel.quantity,
                    TotalAmount = executionModel.totalAmount
                }).ToList(),
                Invoices = order.Invoices.Select(invoiceModel => new invoiceInfos
                {
                    TotalAmount = invoiceModel.totalAmount,
                    CancellationDate = invoiceModel.cancellationDate,
                    CancellationReason = invoiceModel.cancellationReason,
                    InvoiceDate = invoiceModel.invoiceDate,
                    InvoiceID = invoiceModel.invoiceID,
                    InvoiceSerial = invoiceModel.invoiceSerial,
                    IsCancelled = invoiceModel.isCancelled,
                    NetAmount = invoiceModel.netAmount,
                    OrderID = invoiceModel.orderID,
                    TotalOverHeads = invoiceModel.totalOverHeads,
                    TotalQuantity = invoiceModel.totalQuantity
                }).ToList()
            }).ToList();

            return filteredOrdersDTO;
           
        }

        public ordersModel deleteOrder(long id)
        {
            var order = context.Orders
                .Include(o => o.Invoices)
                .Include(o => o.Executions)
                .FirstOrDefault(o => o.orderID == id);
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
            return order;
                
        }

        public ordersModel updateOrder(ordersModel updatedOrder)
        {
                ordersModel olderOrder = context.Orders.Find(updatedOrder.orderID);
                olderOrder.price = updatedOrder.price;
                olderOrder.quantity = updatedOrder.quantity;
                olderOrder.executedQuantity= updatedOrder.executedQuantity;
                olderOrder.marketID = updatedOrder.marketID;
                olderOrder.securityID = updatedOrder.securityID;
                olderOrder.companyCode = updatedOrder.companyCode;
                olderOrder.orderDate = updatedOrder.orderDate;
                olderOrder.orderTime = updatedOrder.orderTime;
                olderOrder.Executions = updatedOrder.Executions;
                olderOrder.Invoices = updatedOrder.Invoices;
                context.SaveChanges();

                return olderOrder;

        }

        public ordersModel createOrder(ordersModel order)
        {
            context.Orders.Add(order);
            context.SaveChanges();

            return order;
        }
    }
}
