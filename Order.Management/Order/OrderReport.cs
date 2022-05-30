using Order.Management.Order.Interface;
using System;
using System.Collections.Generic;

namespace Order.Management.Order
{
    public abstract class OrderReport : IOrderReportService
    {
        public Order Order { get; set; }
        public int TableWidth { get; set; }
        public List<Shape.Shape> Shapes { get; set; }
        public abstract int DisplayOrder { get; }

        protected OrderReport(Order order, int tableWidth, List<Shape.Shape> shapes)
        {
            Order = order;
            TableWidth = tableWidth;
            Shapes = shapes;
        }

        public virtual void GenerateReport()
        {
            GenerateReportHeader();
            Console.WriteLine(Order.ToString());
            GenerateTable();
        }

        public abstract void GenerateReportHeader();

        public abstract void GenerateTable();
    }
}
