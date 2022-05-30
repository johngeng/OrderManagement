using Order.Management.Order.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management.Order
{
    public class OrderService : IOrderService
    {
        private OrderReport _orderReport;

        public OrderService(Order order, OrderReport orderReport)
        {
            _orderReport = orderReport;
        }

        public void GenerateReport()
        {
           // _orderReport.GenerateReport()
        }
    }
}
