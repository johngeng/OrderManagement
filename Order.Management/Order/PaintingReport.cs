using Order.Management.Order.Interface;
using Order.Management.Shape;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Order.Management.Order
{
    public class PaintingReport : OrderReport, IPaintingReport
    {
        private const int TABLEWIDTH = 73;
        public override int DisplayOrder => 3;

        public PaintingReport(Order order, List<Shape.Shape> shapes) : base(order, TABLEWIDTH, shapes) { }


        public override void GenerateReportHeader()
        {
            Console.WriteLine("\nYour painting report has been generated: ");
        }

        public override void GenerateTable()
        {
            Utility.PrintLine(TableWidth);

            var tableHeader =  Enum.GetNames(typeof(Color)).Select(x => $"   {x}   ").ToList();
            tableHeader.Insert(0, "        ");
            Utility.PrintRow(TableWidth, tableHeader.ToArray());
            Utility.PrintLine(TableWidth);

            foreach (var shapeName in Shape.Shape.GetShapes())
            {
                var paramList = new List<string> { shapeName };

                foreach (var color in Enum.GetNames(typeof(Color)))
                {
                    var shapeType = (ShapeType)Enum.Parse(typeof(ShapeType), shapeName);
                    var shapeColor = (Color)Enum.Parse(typeof(Color), color);
                    var shapeQty = Order.GetTotalNumberOfShape(shapeType, shapeColor);
                    paramList.Add(shapeQty.ToString());
                }

                Utility.PrintRow(TableWidth, paramList.ToArray());
            }
            Utility.PrintLine(TableWidth);
        }
    }
}
