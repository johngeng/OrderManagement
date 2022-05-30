using Order.Management.Order.Interface;
using Order.Management.Shape;
using System;
using System.Collections.Generic;

namespace Order.Management.Order
{
    public class CuttingListReport : OrderReport, ICuttingListReport
    {
        private const int TABLEWIDTH = 20;
        public override int DisplayOrder => 2;
        
        public CuttingListReport(Order order, List<Shape.Shape> shapes) : base(order, TABLEWIDTH, shapes) { }

        public override void GenerateReportHeader()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
        }

        public override void GenerateTable()
        {
            Utility.PrintLine(TableWidth);
            Utility.PrintRow(TableWidth, "        ", "   Qty   ");
            Utility.PrintLine(TableWidth);

            foreach (var shapeType in Enum.GetNames(typeof(ShapeType)))
            {
                var shapeQty = Order.GetTotalNumberOfShape((ShapeType)Enum.Parse(typeof(ShapeType), shapeType));
                Utility.PrintRow(TableWidth, shapeType, shapeQty.ToString());
            }
  
            Utility.PrintLine(TableWidth);
        }
    }
}
