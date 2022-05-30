

using Microsoft.Extensions.Configuration;
using Order.Management.Order;
using Order.Management.Order.Interface;
using Order.Management.Shape;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Order.Management
{
    class Program
    {
        // Main entry
        static void Main(string[] args)
        {

            //var builder = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json", optional: false);

            //IConfiguration config = builder.Build();

            var (orderNumber, shapes, additionalCharges,types) = SetupInitalValues();

            var customer = GetCustomerInfoInput();

            var order = GetCustomerOrderInput(orderNumber, customer);
            order.AdditionalCharges = additionalCharges;

            var reports = new List<IOrderReportService>();
            foreach (var reportType in types)
            {
                var report = (IOrderReportService) Activator.CreateInstance(reportType, order, shapes);
                reports.Add(report);
            }
            reports.OrderBy(x => x.DisplayOrder).ToList().ForEach(x => x.GenerateReport());
        }

        private static Tuple<long, List<Shape.Shape>, Dictionary<Color, decimal>, List<Type>> SetupInitalValues()
        {
            var shapes = new List<Shape.Shape>()
            {
                {new Square(1)},
                {new Triangle(2) },
                {new Circle(3) }
            };

            var reportTypes = AppDomain.CurrentDomain.GetAssemblies()
               .SelectMany(s => s.GetTypes())
               .Where(p => typeof(IOrderReportService).IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface)
               .ToList();

            return Tuple.Create(1L, shapes, new Dictionary<Color, decimal>() { { Color.Red, 1 } }, reportTypes);
        }

        // Order Shapes Input
        private static Dictionary<Shape.Shape,Tuple<Color,int>> GetOrderShapeInput(string shapeName)
        {
            var shapesOrdered = new Dictionary<Shape.Shape,Tuple<Color,int>>();
            var shapePrice =  (int) Enum.Parse(typeof(ShapeType), shapeName);
            foreach (var colorName in Enum.GetNames(typeof(Color)))
            {
                var color = (Color)Enum.Parse(typeof(Color), colorName);
                var shape = (Shape.Shape) Activator.CreateInstance(Type.GetType($"Order.Management.Shape.{shapeName}"), (decimal)shapePrice);
              
                Console.Write($"\nPlease input the number of {color} {shape.Type}: ");
                shapesOrdered.Add(shape, Tuple.Create(color, Utility.GetUserInputNumber()));
            }

            return shapesOrdered;
        }

        // Get customer Info
        private static Customer GetCustomerInfoInput()
        {
            Console.Write("Please input your Name: ");
            string customerName = Utility.GetUserInputString();
            Console.Write("Please input your Address: ");
            string address = Utility.GetUserInputString();

            return new Customer(customerName, address);
        }

        // Get order input
        private static Order.Order GetCustomerOrderInput(long orderNumber, Customer customer)
        {
            Console.Write("Please input your Due Date: ");
            var dueDate = Utility.GetUserInputDate();

            var order = new Order.Order(orderNumber, customer, dueDate);

            foreach (var shapeName in Shape.Shape.GetShapes())
            {
              order.AddShapes(GetOrderShapeInput(shapeName));
            }
            return order;
        }
    
    }
}
