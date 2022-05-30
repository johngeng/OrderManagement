using Order.Management.Order.Interface;
using Order.Management.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order.Management.Order
{
    public class InvoiceReport : OrderReport, IInvoiceReport
    {
        private const int TABLEWIDTH = 73;
        public override int DisplayOrder => 1;

        public InvoiceReport(Order order,  List<Shape.Shape> shapes) : base(order, TABLEWIDTH, shapes) { }


        public override void GenerateReportHeader()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
        }

        public void GenerateInvoiceReport()
        {
            GenerateShapeOrderDetails(Shapes);
            AdditionalSurchages();
        }

        public override void GenerateReport()
        {
            base.GenerateReport();
            GenerateInvoiceReport();
        }

        private void GenerateShapeOrderDetails(List<Shape.Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                Console.WriteLine($"\n{shape.Name} 		  {Order.GetTotalNumberOfShape(shape.Type)} @ ${shape.Price} ppi = ${Order.GetTotalPrice(shape.Type, shape.Price)}");
            }
        }

        private void AdditionalSurchages()
        {
       
            foreach (var color in Order.AdditionalCharges.Keys)
            {
                var additionalCharge = Order.AdditionalCharges[color];

                if (additionalCharge > 0)
                {
                    var totalAdditionalCharge = Order.GetTotalNumberOfShape(color) * additionalCharge;

                    Console.WriteLine($"{color} Color Surcharge       {Order.GetTotalNumberOfShape(color)} @ ${additionalCharge} ppi = ${totalAdditionalCharge}");
                }
            }
        }

        public override void GenerateTable()
        {
            Utility.PrintLine(TableWidth);

            var tableHeader = Enum.GetNames(typeof(Color)).Select(x => $"   {x}   ").ToList();
            tableHeader.Insert(0, "        ");
            Utility.PrintRow(TableWidth, tableHeader.ToArray());
            Utility.PrintLine(TableWidth);

            foreach (var shapeTypeName in Enum.GetNames(typeof(ShapeType)))
            {
                var shapeType = (ShapeType)Enum.Parse(typeof(ShapeType), shapeTypeName);
                var paramList = new List<string>() { shapeTypeName };

                foreach (var colorName in Enum.GetNames(typeof(Color)))
                {
                    var color = (Color)Enum.Parse(typeof(Color), colorName);
                    var qty = Order.GetTotalNumberOfShape(shapeType, color);
                    paramList.Add(qty > 0 ? qty.ToString() : "-");
                }

                Utility.PrintRow(TableWidth, paramList.ToArray());
            }

            Utility.PrintLine(TableWidth);
        }
    }
}
