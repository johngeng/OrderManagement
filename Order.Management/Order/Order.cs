using Order.Management.Shape;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Order.Management.Order
{
    public class Order
    {
        public Customer Customer { get; set; }
        public DateTime DueDate { get; set; }
        public long OrderNumber { get; set; }
        public Dictionary<Shape.Shape, Tuple<Color, int>> OrderedBlocks { get; set; }
        public Dictionary<Color, decimal> AdditionalCharges { get; set; }

        public Order(long orderNumber, Customer customer, DateTime dueDate)
        {
            OrderNumber = orderNumber;
            Customer = customer;
            DueDate = dueDate;
            OrderedBlocks = new Dictionary<Shape.Shape, Tuple<Color, int>>();
            AdditionalCharges = new Dictionary<Color, decimal>();
        }

        public void AddShape(Shape.Shape shape, Color color, int qty)
        {
            OrderedBlocks.Add(shape, Tuple.Create(color, qty));
        }

        public void AddShapes(Dictionary<Shape.Shape, Tuple<Color, int>> shapesOrdered)
        {
            OrderedBlocks = OrderedBlocks.Concat(shapesOrdered).ToDictionary(x => x.Key, x => x.Value);
        }

        public int GetTotalNumberOfShape(Color color)
        {
            return OrderedBlocks.Where(x => x.Value.Item1 == color).Sum(y => y.Value.Item2);
        }

        public int GetTotalNumberOfShape(ShapeType shapeType)
        {
            return OrderedBlocks.Where(x => x.Key.Type == shapeType).Sum(y => y.Value.Item2);
        }


        public int GetTotalNumberOfShape(ShapeType shapeType, Color color)
        {
            return OrderedBlocks.Where(x => x.Key.Type == shapeType && x.Value.Item1 == color).Sum(y => y.Value.Item2);
        }

        public int GetTotalNumberOfShape()
        {
            return OrderedBlocks.Sum(x => x.Value.Item2);
        }

        public decimal GetTotalPrice(ShapeType shapeType, decimal price)
        {
            var qty = GetTotalNumberOfShape(shapeType);
            return qty * price;
        }


        public override string ToString()
        {
            return $"Name:{Customer.CustomerName} Address:{Customer.Address} Due Date:{DueDate.ToShortDateString()} Order #: {OrderNumber.ToString().PadLeft(3,'0')}";
        }

    }
}
